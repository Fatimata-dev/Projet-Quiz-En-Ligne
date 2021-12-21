using Projet_Quiz_En_Ligne.Models;
using Projet_Quiz_En_Ligne.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Projet_Quiz_En_Ligne.Services
{
    public class CategoryService : ICategoryService
    {
        private ICategoryRepository repo;

        public CategoryService(ICategoryRepository repo)
        {
            this.repo = repo;
        }

        public void DeleteById(int id)
        {
            repo.DeleteById(id);
        }

        public List<Category> FindAll()
        {
            return repo.FindAll();
        }

        public Category FindById(int id)
        {
           return repo.FindById(id);
        }

        public void Insert(Category ctgr)
        {
            repo.Insert(ctgr);
        }

        public void Update(Category ctgr)
        {
            repo.Update(ctgr);
        }
    }
}