using Projet_Quiz_En_Ligne.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_Quiz_En_Ligne.Services
{
    public interface ICategoryService
    {
        List<Category> FindAll();
        void Update(Category ctgr);
        Category FindById(int id);
        void DeleteById(int id);

        void Insert(Category ctgr);
    }
}
