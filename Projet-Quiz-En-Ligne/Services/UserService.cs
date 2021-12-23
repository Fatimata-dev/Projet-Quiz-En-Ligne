using Projet_Quiz_En_Ligne.Models;
using Projet_Quiz_En_Ligne.Repositories;
using Projet_Quiz_En_Ligne.Tools;
using Projet_Quiz_En_Ligne.ViewModel;
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

        public List<UserResultViewModel> FindAll()
        {
            return repo.FindAll();
        }

        //public User GetById(int id)
        //{
        //    return repo.GetById(id);
        //}

        public UserResultViewModel GetUser(UserResultViewModel userVM)
        {
            userVM.Password = HashTool.CryptPassword(userVM.Password);
            UserResultViewModel userViewModel =  repo.GetUser(userVM);
            return userViewModel;
        }

        public void Insert(UserResultViewModel userVM)
        {
            userVM.Password = HashTool.CryptPassword(userVM.Password);
            repo.Insert(userVM);
        }

        public void Update(UserResultViewModel userVM)
        {
            userVM.Password = HashTool.CryptPassword(userVM.Password);
            repo.Update(userVM);
        }
    }
}