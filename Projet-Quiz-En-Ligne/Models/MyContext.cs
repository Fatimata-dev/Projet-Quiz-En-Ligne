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
        public  DbSet<QuizQuestion> QuizQuestions { get; set; }
        public  DbSet<QuizReponse> QuizReponses { get; set; }
        public  DbSet<QuizCategory> QuizCategories { get; set; }
        public  DbSet<Resultat> Resultats { get; set; }
        public  DbSet<User> Users { get; set; }
    }

}