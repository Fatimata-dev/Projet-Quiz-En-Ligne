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
        public void DeleteById(int id)
        {
            QuizCategory quizCategory = context.QuizCategories.FirstOrDefault(qzc => qzc.Id == id);
            context.Entry(quizCategory).State = EntityState.Deleted;
            context.SaveChanges();
        }

        public List<QuizCategory> FindAll()
        {
            return context.QuizCategories.AsNoTracking().ToList();
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
                ctgr.Title =quizCategory.Title;

            }
            else
            {
                context.QuizCategories.Add(ctgr);
            }
            context.SaveChanges();
        }
    }
}