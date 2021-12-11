using Projet_Quiz_En_Ligne.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_Quiz_En_Ligne.Repositories
{
    interface IUserRepository
    {
        List<User> FindAll();
        void Insert(User user);
    }
}
