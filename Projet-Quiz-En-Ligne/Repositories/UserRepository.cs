    using Projet_Quiz_En_Ligne.Models;
using Projet_Quiz_En_Ligne.Tools;
using Projet_Quiz_En_Ligne.ViewModel;
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
            User user = context.Users.Find(id);
            context.Users.Remove(user);
            context.SaveChanges();
        }

        public List<UserResultViewModel> FindAll()
        {
            List<UserResultViewModel> lst = new List<UserResultViewModel>();
            List<User> users =  context.Users.AsNoTracking().ToList();
            foreach (var user in users)
            {
                lst.Add(Convertisseur.UuserViewModelFromUser(new UserResultViewModel(), user));
            }
            return lst;
        }

        //public UserResultViewModel GetById(int id)
        //{
        //    UserResultViewModel userVM = null;
        //    User user = context.Users.FirstOrDefault(u => u.Id == id);
        //    if (user != null)
        //    {
        //        userVM = Convertisseur.UuserViewModelFromUser(userViewModel, user);
        //    }
        //    return user;
        //}

        public UserResultViewModel GetUser(UserResultViewModel userViewModel)
        {
            UserResultViewModel userVM = null;
            User user = context.Users.FirstOrDefault(u => u.Email == userViewModel.Email && u.Password == userViewModel.Password);
            if (user != null)
            {
                userVM = Convertisseur.UuserViewModelFromUser(userViewModel, user);
            }
            return userVM;
            
        }

        public void Insert(UserResultViewModel userViewModel)
        {
            User user = Convertisseur.UserFromUserViewModel(userViewModel, new User());
            context.Users.Add(user);
            context.SaveChanges();
        }

        public void Update(UserResultViewModel userViewModel)
        {
            User user = Convertisseur.UserFromUserViewModel(userViewModel, new User());

            if (user != null)
            {
                context.Entry(user).State = EntityState.Modified;
                context.SaveChanges();
            }
        }


    }
}