using Projet_Quiz_En_Ligne.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Projet_Quiz_En_Ligne.ViewModel
{
    public class UserResultViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "User Name obligatoire")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Mot de passe obligatoire")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public bool IsAdmin { get; set; }

        [EmailAddress]
        [Required(ErrorMessage = "Email obligatoire")]
        public string Email { get; set; }
        public Quiz quiz { get; set; }
        public Resultat resultat { get; set; }
        public int TotalPoints { get; set; }
    }
}