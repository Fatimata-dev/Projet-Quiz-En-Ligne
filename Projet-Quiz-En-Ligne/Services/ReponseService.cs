using Projet_Quiz_En_Ligne.Models;
using Projet_Quiz_En_Ligne.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Projet_Quiz_En_Ligne.Services
{
    public class ReponseService : IReponseService
    {
        private IReponseRepository repo;

        public ReponseService(IReponseRepository repo)
        {
            this.repo = repo;
        }

        public void Delete(int id)
        {
            repo.DeleteById(id);
        }

        public List<QuizReponse> FindAll()
        {
            return repo.FindAll();
        }

        public QuizReponse GetById(int id)
        {
            return repo.GetById(id);
        }

        public void Insert(QuizReponse rep)
        {
            repo.Insert(rep);
        }

        public void Update(QuizReponse rep)
        {
            repo.Update(rep);
        }
    }
}