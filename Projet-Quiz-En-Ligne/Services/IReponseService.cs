using Projet_Quiz_En_Ligne.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_Quiz_En_Ligne.Services
{
    public interface IReponseService
    {
        List<QuizReponse> FindAll();
        void Update(QuizReponse rep);
        QuizReponse GetById(int id);
        void Delete(int id);

        void Insert(QuizReponse rep);
    }
}
