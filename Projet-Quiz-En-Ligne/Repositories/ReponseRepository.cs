using Projet_Quiz_En_Ligne.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Projet_Quiz_En_Ligne.Repositories
{
    public class ReponseRepository : IReponseRepository
    {
        private MyContext context;

        public ReponseRepository(MyContext context)
        {
            this.context = context;
        }

        public void DeleteById(int id)
        {
            QuizReponse rep = context.QuizReponses.Find(id);
            if (rep != null)
            {
                context.Entry(rep).State = EntityState.Deleted;
                context.SaveChanges();
            }
            else
            {
                throw new Exception("Suppression impossible");
            }
           
        }

        public List<QuizReponse> FindAll()
        {
            return context.QuizReponses.AsNoTracking().ToList();
        }

        public QuizReponse GetById(int id)
        {
            return context.QuizReponses.Find(id);
        }

        public void Insert(QuizReponse rep)
        {
            context.QuizReponses.Add(rep);
            context.SaveChanges();
        }

        public void Update(QuizReponse rep)
        {
            if (rep != null)
            {
                context.Entry(rep).State = EntityState.Modified;
                context.SaveChanges();
            }
            else
            {
                throw new Exception("Impossible de modifier");
            }
        }
    }
}