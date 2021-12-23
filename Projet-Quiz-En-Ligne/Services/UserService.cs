using Projet_Quiz_En_Ligne.Models;
using Projet_Quiz_En_Ligne.Repositories;
using Projet_Quiz_En_Ligne.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Projet_Quiz_En_Ligne.Services
{
    public class UserService:IUserService
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

        public User GetUser(User user)
        {
            user.Password = HashTool.CryptPassword(user.Password);
            return repo.GetUser(user);
        }

        public void Insert(User user)
        {
            user.Password = HashTool.CryptPassword(user.Password);
            repo.Insert(user);
        }

        public void Update(User user)
        {
            user.Password = HashTool.CryptPassword(user.Password);
            repo.Update(user);
        }
    }
}