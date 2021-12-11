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
        public List<QuizQuestion> Questions { get; set; }

        
        [ForeignKey("CategoryId")]
        public QuizCategory Category { get; set; }
        public int? CategoryId { get; set; }

        public Quiz(string sujet, QuizCategory category)
        {
            Category = category;
            Sujet = sujet;
            Questions = new List<QuizQuestion>();
        }

        public Quiz()
        {
        }
    }
}