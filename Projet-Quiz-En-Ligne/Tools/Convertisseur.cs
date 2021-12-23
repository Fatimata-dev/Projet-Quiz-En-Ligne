using AutoMapper;
using Projet_Quiz_En_Ligne.Models;
using Projet_Quiz_En_Ligne.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Projet_Quiz_En_Ligne.Tools
{
    public class Convertisseur
    { 
        public static UserResultViewModel UuserViewModelFromUser(UserResultViewModel userVM, User user)
        {
            IMapper mapper = MapperTools.Conf.CreateMapper();

            //Mapping
            userVM = mapper.Map(user, userVM);

            return userVM;
        }

        public static User UserFromUserViewModel(UserResultViewModel userVM, User user)
        {
            IMapper mapper = MapperTools.Conf.CreateMapper();

            //Mapping
            user = mapper.Map(userVM, user);
            return user;
        }

    }
}