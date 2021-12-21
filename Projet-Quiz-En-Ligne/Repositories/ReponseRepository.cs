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
            Reponse rep = context.Reponses.Find(id);
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

        public List<Reponse> FindAll()
        {
            return context.Reponses.AsNoTracking().ToList();
        }

        public Reponse GetById(int id)
        {
            return context.Reponses.Find(id);
        }

        public void Insert(Reponse rep)
        {
            context.Reponses.Add(rep);
            context.SaveChanges();
        }

        public void Update(Reponse rep)
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