using Projet_Quiz_En_Ligne.Models;
using Projet_Quiz_En_Ligne.Repositories;
using Projet_Quiz_En_Ligne.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Projet_Quiz_En_Ligne.Controllers
{
    public class HomeController : Controller
    {
        private QuizQuestionService service = new QuizQuestionService(new QuizQuestionRepository(new MyContext()));
        private ReponseService reponse = new ReponseService(new ReponseRepository(new MyContext()));
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Quiz(QuizQuestion quizQuestion)
        {
            List<QuizQuestion> questions = service.FindAll();
            return View(questions);
        }
    }
}