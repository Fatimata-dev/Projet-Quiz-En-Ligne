using Projet_Quiz_En_Ligne.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Projet_Quiz_En_Ligne.Repositories
{
    public class QuestionRepository : IQuestionRepository
    {
        private MyContext context;

        public QuestionRepository(MyContext context)
        {
            this.context = context;
        }

        public void DeleteById(int id)
        {
            Question question = context.Questions.Find(id);
            if (question != null)
            {
                context.Questions.Remove(question);
                context.SaveChanges();
            }
            else
            {
                throw new Exception("Impossible de Supprimer");
            }   
        }

        public Question FindById(int id)
        {
            return context.Questions.Find(id);
        }

        public List<Question> FindQuizzes()
        {
            return context.Questions.Include(qzq => qzq.Reponses).AsNoTracking().ToList();
        }

        public void Insert(Question quizQ)
        {
            context.Questions.Add(quizQ);
            context.SaveChanges();
        }

        public void Update(Question quizQ)
        {
            if (quizQ != null)
            {
                context.Entry(quizQ).State = EntityState.Modified;
                context.SaveChanges();
            }
            else
            {
                throw new Exception("Impossible de modifier");
            }
        }
    }
}