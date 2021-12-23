using AutoMapper;
using Projet_Quiz_En_Ligne.Models;
using Projet_Quiz_En_Ligne.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Projet_Quiz_En_Ligne.Tools
{
    public class MapperTools
    {
        public static MapperConfiguration Conf { get; set; }

        public static MapperConfiguration Configure()
        {
            Conf = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<User, UserResultViewModel>();
                cfg.CreateMap<UserResultViewModel, User>();
            });
            return Conf;
        }
    }
}