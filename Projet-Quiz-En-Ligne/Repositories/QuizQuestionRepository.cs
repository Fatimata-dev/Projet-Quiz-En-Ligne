using Projet_Quiz_En_Ligne.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Projet_Quiz_En_Ligne.Repositories
{
    public class QuizQuestionRepository : IQuizQuestionRepository
    {
        private MyContext context;

        public QuizQuestionRepository(MyContext context)
        {
            this.context = context;
        }

        public void DeleteById(int id)
        {
            QuizQuestion quizQuestion = context.QuizQuestions.Find(id);
            if (quizQuestion != null)
            {
                context.Entry(quizQuestion).State = EntityState.Deleted;
                context.SaveChanges();
            }
            else
            {
                throw new Exception("Impossible de Supprimer");
            }
        }

        public List<QuizQuestion> FindQuizzes()
        {
            return context.QuizQuestions.Include(qzq => qzq.Reponses).AsNoTracking().ToList();
            context.SaveChanges();
        }

        public void Insert(QuizQuestion quizQ)
        {
            context.QuizQuestions.Add(quizQ);
            context.SaveChanges();
        }

        public void Update(QuizQuestion quizQ)
        {
            QuizQuestion quizQuestion = context.QuizQuestions.SingleOrDefault(q => q.Id == quizQ.Id);
            if (quizQuestion != null)
            {
                context.Entry(quizQuestion).State = EntityState.Modified;
                context.SaveChanges();
            }
            else
            {
                throw new Exception("Impossible de modifier");
            }
        }
    }
}