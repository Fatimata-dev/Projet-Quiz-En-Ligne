using Projet_Quiz_En_Ligne.Models;
using Projet_Quiz_En_Ligne.Repositoriy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Projet_Quiz_En_Ligne.Service
{

    public class UserService : IUserService
    {
        private IUserRepository repo;

        public UserService(IUserRepository repo)
        {
            this.repo = repo;
        }

        public void Delete(int id)
        {
            repo.Delete(id);
        }

        public List<User> FindAll()
        {
            return repo.FindAll();
        }

        public User GetById(int id)
        {
            return repo.GetById(id);
        }

        public User GetUser(string Email, string Password)
        {
            return repo.GetUser(Email, Password);
        }

        public void Insert(User user)
        {
            repo.Insert(user);
        }

        public void Update(User user)
        {
            repo.Update(user);
        }
    }
}