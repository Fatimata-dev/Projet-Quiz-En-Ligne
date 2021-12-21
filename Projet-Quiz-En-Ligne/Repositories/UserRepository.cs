    using Projet_Quiz_En_Ligne.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Projet_Quiz_En_Ligne.Repositories
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
            User user = context.Users.SingleOrDefault(u => u.Id == id);
            if (user != null)
            {
                context.Entry(user).State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public List<User> FindAll()
        {
            return context.Users.AsNoTracking().ToList();
        }

        public void Insert(User user)
        {
            context.Users.Add(user);
            context.SaveChanges();
        }

       
    }
}