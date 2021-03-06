using Projet_Quiz_En_Ligne.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_Quiz_En_Ligne.Repositories
{
    public interface IResultRepository
    {
        List<Resultat> FindUserResults( int userId);
        Resultat FindOne( int userId, int quizId);
        void Add(Resultat resultat);
    }
}
