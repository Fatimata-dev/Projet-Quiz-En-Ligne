using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Projet_Quiz_En_Ligne.Models
{
    public class Quiz
    {
        public int? Id { get; set; }
        public string Sujet { get; set; }
        public virtual List<QuizQuestion> Questions { get; set; }

        public string Image { get; set; }
        public string Category { get; set; }

        public Quiz(string sujet,string category)
        {
            Category = category;
            Sujet = sujet;
            Questions = new List<QuizQuestion>();
        }

        public Quiz()
        {
            Questions = new List<QuizQuestion>();
        }
    }
}