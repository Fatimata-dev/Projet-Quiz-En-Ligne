using Projet_Quiz_En_Ligne.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_Quiz_En_Ligne.Repositoriy
{
   public interface IUserRepository
    {
        List<User> FindAll();
        void Insert(User user);
        void Update(User user);
        void Delete(int id);
        User GetUser(string Email, string Password);
        User GetById(int id);
    }
}
