using System;
using System.Data.Entity;
using System.Linq;

namespace Projet_Quiz_En_Ligne.Models
{
    public class MyContext : DbContext
    {
        public MyContext()
            : base("name=MyContext")
        {
        }

        public  DbSet<Quiz> Quizzes { get; set; }
        public  DbSet<Question> Questions { get; set; }
        public  DbSet<Reponse> Reponses { get; set; }
        public  DbSet<Category> Categories { get; set; }
        public  DbSet<Resultat> Resultats { get; set; }
        public  DbSet<User> Users { get; set; }

        public System.Data.Entity.DbSet<Projet_Quiz_En_Ligne.ViewModel.UserResultViewModel> UserResultViewModels { get; set; }
    }

}