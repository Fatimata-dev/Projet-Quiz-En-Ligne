using Projet_Quiz_En_Ligne.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Projet_Quiz_En_Ligne.Repositories
{
    public class ResultRepository : IResultRepository
    {
        private MyContext context;

        public ResultRepository(MyContext context)
        {
            this.context = context;
        }

        public void Add(Resultat resultat)
        {
            context.Resultats.Add(resultat);
            context.SaveChanges();
        }

        public Resultat FindOne(int userId, int quizId)
        {
            return context.Resultats.FirstOrDefault(r => r.QuizId == quizId && r.UserId == userId);
        }

        public List<Resultat> FindUserResults( int userId, int quizId)
        {
            return context.Resultats.AsNoTracking().Where(r => r.QuizId == quizId && r.UserId == userId).ToList();
        }
    }
}