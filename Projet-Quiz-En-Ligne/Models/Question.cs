using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Projet_Quiz_En_Ligne.Models
{
    public class Question
    {
        public int? Id { get; set; }
        public string QstText { get; set; }
        public bool IsMultiple { get; set; }
        public int NumOrder { get; set; }

        [ForeignKey("QuizId")]
        public virtual Quiz Quiz { get; set; }
        public int? QuizId { get; set; }

        public virtual List<Reponse> Reponses { get; set; }
        public Question(string qstText, bool isMultiple, int numOrder)
        {
            QstText = qstText;
            IsMultiple = isMultiple;
            NumOrder = numOrder;
            Reponses = new List<Reponse>();
        }

        public Question()
        {
            Reponses = new List<Reponse>();
        }
    }
}