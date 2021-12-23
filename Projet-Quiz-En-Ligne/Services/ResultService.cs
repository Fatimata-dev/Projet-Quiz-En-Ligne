using Projet_Quiz_En_Ligne.Models;
using Projet_Quiz_En_Ligne.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Projet_Quiz_En_Ligne.Services
{
    public class ResultService : IResultService
    {
        private IResultRepository repo;

        public ResultService(IResultRepository repo)
        {
            this.repo = repo;
        }

        public void Add(Resultat resultat)
        {
            repo.Add(resultat);
        }

        public Resultat FindOne(int userId, int quizId)
        {
            return repo.FindOne(userId, quizId);
        }

        public List<Resultat> FindUserResults(int userId, int quizId)
        {
            return repo.FindUserResults(userId, quizId);
        }
    }
}