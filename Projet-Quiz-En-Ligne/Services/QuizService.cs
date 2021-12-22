using Projet_Quiz_En_Ligne.Models;
using Projet_Quiz_En_Ligne.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Projet_Quiz_En_Ligne.Services
{
    public class QuizService : IQuizService
    {
        private IQuizRepository repo;

        public QuizService(IQuizRepository repo)
        {
            this.repo = repo;
        }

        public void DeleteById(int id)
        {
            repo.DeleteById(id);
        }

        public Quiz FindById(int id)
        {
            return repo.FindById(id);
        }

        public Question FindQuestion(int quizId, int numOrder)
        {
            return repo.FindQuestion(quizId, numOrder);
        }

        public List<Quiz> FindAll()
        {
            return repo.FindQuizzes();
        }

        public Reponse FindResponseById(int responseId)
        {
            return repo.FindResponseById(responseId);
        }

        public List<Reponse> FindResponses(int questionId)
        {
            return repo.FindResponses(questionId);
        }

        public void Insert(Quiz quiz)
        {
            repo.Insert(quiz);
        }

        public void Update(Quiz quiz)
        {
            repo.Update(quiz);
        }

        public List<Quiz> FindByCat(string category)
        {
            return repo.FindByCat(category);
        }
    }
}