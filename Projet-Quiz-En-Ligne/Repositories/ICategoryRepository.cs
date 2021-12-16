using Projet_Quiz_En_Ligne.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_Quiz_En_Ligne.Repositories
{
    public interface ICategoryRepository
    {
        List<QuizCategory> FindAll();
        void Update(QuizCategory ctgr);
        void DeleteById(int id);
        QuizCategory FindById(int id);

        void Insert(QuizCategory ctgr);
    }
}
