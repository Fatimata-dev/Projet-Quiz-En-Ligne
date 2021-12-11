using Projet_Quiz_En_Ligne.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_Quiz_En_Ligne.Repositories
{
    public interface IQuizQuestion
    {
        List<QuizQuestion> FindQuizzes();
        void DeleteById(int id);
        void Update(QuizQuestion quizQ);
        void Insert(QuizQuestion quizQ);
    }
}
