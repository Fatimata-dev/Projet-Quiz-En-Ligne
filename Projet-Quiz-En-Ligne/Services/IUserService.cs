using Projet_Quiz_En_Ligne.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_Quiz_En_Ligne.Services
{
    public interface IUserService
    {
        List<User> FindAll();
        void Insert(User user);
        void Update(User user);
        void Delete(int id);
        User GetUser(User user);
        User GetById(int id);
    }
}
