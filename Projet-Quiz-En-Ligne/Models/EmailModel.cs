using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Projet_Quiz_En_Ligne.Models
{
    public class EmailModel
    {
         [Required(ErrorMessage = "Champ obligatoire")]
        [Display(Name = "Nom :")]
        public string To { get; set; }
        [Required(ErrorMessage = "Champ obligatoire")]

        public string Subject { get; set; }
        [Required(ErrorMessage = "Champ obligatoire")]

        public string Body { get; set; }
        [Required(ErrorMessage = "Champ obligatoire")]

        public string Email { get; set; }
        [Required(ErrorMessage = "Champ obligatoire")]

        public string Password { get; set; }
    }
}