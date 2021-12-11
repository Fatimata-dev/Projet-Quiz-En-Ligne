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


        public void DeleteById(int id)
        {
            Quiz qz = context.Quizzes.SingleOrDefault(q => q.Id == id);
            context.Entry(qz).State = EntityState.Deleted;
            context.SaveChanges();
        }

        public QuizQuestion FindQuestion(int quizId, int numOrder)
        {
            return context.QuizQuestions.AsNoTracking().SingleOrDefault(qst => qst.QuizId == quizId && qst.NumOrder == numOrder);
        }

        public List<Quiz> FindQuizzes()
        {
            //Avec le Include on peut faire la jointure et recuperer les valeurs de db.Quizzes.Include(...)
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
            Quiz qz = context.Quizzes.SingleOrDefault(q => q.Id == quiz.Id);
            if (qz == null)
            {
                context.Quizzes.Add(quiz);
            }
            else
            {
                quiz.Category = qz.Category;
                quiz.Questions = new List<QuizQuestion>();
                
            }
            context.SaveChanges();
        }
    }
}