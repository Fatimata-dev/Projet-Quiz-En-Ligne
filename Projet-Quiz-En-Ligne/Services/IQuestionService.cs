using Projet_Quiz_En_Ligne.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_Quiz_En_Ligne.Services
{
    public interface IQuestionService
    {
        List<Question> FindAll();
        Question FindById(int id);
        void Delete(int id);
        void Update(Question quizQ);
        void Insert(Question quizQ);
    }
}
