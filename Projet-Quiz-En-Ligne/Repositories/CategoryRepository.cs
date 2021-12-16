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
            QuizCategory quizCategory = context.QuizCategories.Find(id);
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

        public List<QuizCategory> FindAll()
        {
            return context.QuizCategories.AsNoTracking().ToList();
        }

        public QuizCategory FindById(int id)
        {
            return context.QuizCategories.Find(id);
        }

        public void Insert(QuizCategory ctgr)
        {
            context.QuizCategories.Add(ctgr);
            context.SaveChanges();
        }

        public void Update(QuizCategory ctgr)
        {
            QuizCategory quizCategory = context.QuizCategories.FirstOrDefault(qzc => qzc.Id == ctgr.Id);
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