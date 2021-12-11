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

        public virtual DbSet<Quiz> Quizzes { get; set; }
        public virtual DbSet<QuizQuestion> QuizQuestions { get; set; }
        public virtual DbSet<QuizReponse> QuizReponses { get; set; }
        public virtual DbSet<QuizCategory> QuizCategories { get; set; }
        public virtual DbSet<QuizTest> QuizTests { get; set; }
        public virtual DbSet<User> Users { get; set; }
    }

}