using Projet_Quiz_En_Ligne.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Projet_Quiz_En_Ligne.ViewModel
{
    public class ListQuizsCategoriesViewModel
    {
        public List<Quiz> Quizs { get; set; }
        public List<Category> Categories { get; set; }
    }
}