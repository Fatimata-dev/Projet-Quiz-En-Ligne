using Projet_Quiz_En_Ligne.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Projet_Quiz_En_Ligne.Repositories
{
    public class QuizRepository : IQuizRepository
    {
        private MyContext context;
        public QuizRepository(MyContext context)
        {
            this.context = context;
        }

        public void DeleteById(int id)
        {
            Quiz qz = context.Quizzes.Find(id);
            if (qz != null)
            {
                context.Quizzes.Remove(qz);
                context.SaveChanges();
            }
            else
            {
                throw new Exception("Impossible de supprimer");
            }
        }

        public List<Quiz> FindByCat(string category)
        {
            return context.Quizzes.AsNoTracking().Where(q => q.Category == category).ToList();
        }

        public Quiz FindById(int id)
        {
            return context.Quizzes.FirstOrDefault(q => q.Id == id);
            
        }

        public Question FindQuestion(int quizId, int numOrder)
        {
            return context.Questions.AsNoTracking().SingleOrDefault(qst => qst.QuizId == quizId && qst.NumOrder == numOrder);
        }

        public List<Quiz> FindQuizzes()
        {
            return context.Quizzes.AsNoTracking().ToList();
        }

        public Reponse FindResponseById(int responseId)
        {
            return context.Reponses.FirstOrDefault(r => r.Id == responseId);
        }

        public List<Reponse> FindResponses(int questionId)
        {
            return context.Reponses.AsNoTracking().Where(r => r.QuestionId == questionId).ToList();
        }

        public void Insert(Quiz quiz)
        {
            context.Quizzes.Add(quiz);
            context.SaveChanges();
        }

        public void Update(Quiz quiz)
        {
            //Quiz q = context.Quizzes.FirstOrDefault(qz => qz.Id == quiz.Id);
            //if (q != null)
            //{
            context.Quizzes.Attach(quiz);
               context.Entry(quiz).State = EntityState.Modified;
               context.SaveChanges();
            //}
            //else
            //{
            //    throw new Exception("Impossible de modifier");
                
            //}
        }
    }
}