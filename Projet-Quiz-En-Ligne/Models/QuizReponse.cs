using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Projet_Quiz_En_Ligne.Models
{
    public class QuizReponse
    {

        public int? Id { get; set; }
        public string RespText { get; set; }
        public bool IsCorrect { get; set; }

        //ManyToOne
        [ForeignKey("QuestionId")]
        public QuizQuestion Question { get; set; }
        public int? QuestionId { get; set; }

        public QuizReponse(string respText, bool isCorrect)
        {
            RespText = respText;
            IsCorrect = isCorrect;
        }

        public QuizReponse()
        {
        }
    }
}