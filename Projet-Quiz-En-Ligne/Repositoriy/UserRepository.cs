using Projet_Quiz_En_Ligne.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Projet_Quiz_En_Ligne.Repositoriy
{
    public class UserRepository : IUserRepository
    {
        private MyContext context;

        public UserRepository(MyContext context)
        {
            this.context = context;
        }

        public void Delete(int id)
        {
            User user = context.Users.Find(id);
            context.Users.Remove(user);
            context.SaveChanges();
        }

        public List<User> FindAll()
        {
            return context.Users.AsNoTracking().ToList();
        }

        public User GetById(int id)
        {
            User user = context.Users.FirstOrDefault(u => u.Id == id);
            return user;
        }

        public User GetUser(string Email, string Password)
        {
            User user = context.Users.FirstOrDefault(u => u.Email == Email && u.Password == Password);
            return user;
        }

        public void Insert(User user)
        {
            context.Users.Add(user);
            context.SaveChanges();
        }

        public void Update(User user)
        {
            if(user != null)
            {
                context.Entry(user).State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}