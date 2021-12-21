using Projet_Quiz_En_Ligne.Models;
using Projet_Quiz_En_Ligne.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Projet_Quiz_En_Ligne.Services
{
    public class QuestionService : IQuestionService
    {
        private IQuestionRepository repo;

        public QuestionService(IQuestionRepository repo)
        {
            this.repo = repo;
        }

        public void Delete(int id)
        {
            repo.DeleteById(id);
        }

        public List<Question> FindAll()
        {
            return repo.FindQuizzes();
        }

        public Question FindById(int id)
        {
            return repo.FindById(id);
        }

        public void Insert(Question quizQ)
        {
            repo.Insert(quizQ);
        }

        public void Update(Question quizQ)
        {
            repo.Update(quizQ);
        }
    }
}