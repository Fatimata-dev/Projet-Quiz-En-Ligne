using Projet_Quiz_En_Ligne.Models;
using Projet_Quiz_En_Ligne.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_Quiz_En_Ligne.Repositories
{
    public interface IUserRepository
    {
        List<UserResultViewModel> FindAll();
        void Insert(UserResultViewModel userViewModel);
        void Update(UserResultViewModel userViewModel);
        void Delete(int id);
        UserResultViewModel GetUser(UserResultViewModel userViewModel);
        //UserResultViewModel GetById(int id);
    }
}
