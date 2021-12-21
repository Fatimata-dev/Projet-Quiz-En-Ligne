using Projet_Quiz_En_Ligne.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Projet_Quiz_En_Ligne.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private MyContext context;

        public CategoryRepository(MyContext context)
        {
            this.context = context;
        }

        public void DeleteById(int id)
        {
            Category quizCategory = context.Categories.Find(id);
            if (quizCategory != null)
            {
                context.Entry(quizCategory).State = EntityState.Deleted;
                context.SaveChanges();
            }
            else
            {
                throw new Exception("Impossible de supprimer");
            }
            
        }

        public List<Category> FindAll()
        {
            return context.Categories.AsNoTracking().ToList();
        }

        public Category FindById(int id)
        {
            return context.Categories.Find(id);
        }

        public void Insert(Category ctgr)
        {
            context.Categories.Add(ctgr);
            context.SaveChanges();
        }

        public void Update(Category ctgr)
        {
            Category quizCategory = context.Categories.FirstOrDefault(qzc => qzc.Id == ctgr.Id);
            if (quizCategory != null)
            {
                ctgr.Name =quizCategory.Name;

            }
            else
            {
                throw new Exception("Impossible de Modifier");
            }
            context.SaveChanges();
        }
    }
}