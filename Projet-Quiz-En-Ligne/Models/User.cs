using System.ComponentModel.DataAnnotations;

namespace Projet_Quiz_En_Ligne.Models
{
    public class User
    {
        public User()
        {
        }

        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public bool IsAdmin { get; set; }
        public Quiz quiz { get; set; }
        public Resultat resultat { get; set; }
        public override string ToString()
        {
            return Name;
        }
    }
}