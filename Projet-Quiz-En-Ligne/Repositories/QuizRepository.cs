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

        public Quiz FindById(int id)
        {
            return context.Quizzes.Find(id);
            
        }

        public QuizQuestion FindQuestion(int quizId, int numOrder)
        {
            return context.QuizQuestions.AsNoTracking().SingleOrDefault(qst => qst.QuizId == quizId && qst.NumOrder == numOrder);
        }

        public List<Quiz> FindQuizzes()
        {
            return context.Quizzes.AsNoTracking().ToList();
        }

        public QuizReponse FindResponseById(int responseId)
        {
            return context.QuizReponses.Find(responseId);
        }

        public List<QuizReponse> FindResponses(int questionId)
        {
            return context.QuizReponses.AsNoTracking().Where(r => r.QuestionId == questionId).ToList();
        }

        public void Insert(Quiz quiz)
        {
            context.Quizzes.Add(quiz);
            context.SaveChanges();
        }

        public void Update(Quiz quiz)
        {
            //Quiz quiz1 = context.Quizzes.SingleOrDefault(q => q.Id == quiz.Id);
            if (quiz != null)
            {
                context.Entry(quiz).State = EntityState.Modified;
                context.SaveChanges();
            }
            else
            {
                throw new Exception("Impossible de modifier");
                
            }
        }
    }
}