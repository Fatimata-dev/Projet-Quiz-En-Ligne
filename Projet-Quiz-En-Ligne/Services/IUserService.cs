using Projet_Quiz_En_Ligne.Models;
using Projet_Quiz_En_Ligne.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_Quiz_En_Ligne.Services
{
    public interface IUserService
    {
        List<UserResultViewModel> FindAll();
        void Insert(UserResultViewModel userVM);
        void Update(UserResultViewModel userVM);
        void Delete(int id);
        UserResultViewModel GetUser(UserResultViewModel userVM);
        //User GetById(int id);
    }
}
