using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Projet_Quiz_En_Ligne.Models
{
    public class QuizTest
    {
        
        public int? Id { get; set; }
        public DateTime CreationDate { get; set; }

        //ManyToOne
        [ForeignKey("UserId")]
        public User User { get; set; }
        public int? UserId { get; set; }

        //ManyToOne
        [ForeignKey("QuizId")]
        public Quiz Quiz { get; set; }
        public int? QuizId { get; set; }

        public Dictionary<QuizQuestion, List<QuizReponse>> UserReponses { get; set; }

        public int Score { get; set; }

        public QuizTest(DateTime creationDate, User user, Quiz quiz, int score)
        {
            CreationDate = creationDate;
            User = user;
            Quiz = quiz;
            UserReponses = new Dictionary<QuizQuestion, List<QuizReponse>>();
            Score = score;
        }

        public QuizTest()
        {
        }
    }
}