using Projet_Quiz_En_Ligne.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Projet_Quiz_En_Ligne.ViewModel
{
    public class QuizCategoryViewModel
    {
        public Quiz Quiz { get; set; }
        public List<Category> Categories { get; set; }
    }
}