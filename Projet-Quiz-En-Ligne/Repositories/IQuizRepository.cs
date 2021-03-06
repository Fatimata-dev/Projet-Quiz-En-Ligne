using Projet_Quiz_En_Ligne.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_Quiz_En_Ligne.Repositories
{
    public interface IQuizRepository
    {
        List<Quiz> FindQuizzes();
        Question FindQuestion(int quizId, int numOrder);
        List<Quiz> FindByCat(string category);
        List<Reponse> FindResponses(int questionId);
        Reponse FindResponseById(int responseId);
        Quiz FindById(int id);
        void DeleteById(int id);
        void Update(Quiz quiz);
        void Insert(Quiz quiz);
    }
}
