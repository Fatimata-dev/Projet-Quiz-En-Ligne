using Projet_Quiz_En_Ligne.Models;
using Projet_Quiz_En_Ligne.Repositories;
using Projet_Quiz_En_Ligne.Services;
using Projet_Quiz_En_Ligne.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Projet_Quiz_En_Ligne.Controllers
{
    public class HomeController : Controller
    {
        private QuizService service = new QuizService(new QuizRepository(new MyContext()));
        private CategoryService categoryService = new CategoryService(new CategoryRepository(new MyContext()));
        private QuestionService questionService = new QuestionService(new QuestionRepository(new MyContext()));
        // GET: Home
        public ActionResult Index(string Category = null)
        {
            List<Quiz> Quizs;
            List<Category> Categories = categoryService.FindAll();

            if (Category == null)
            {
                Quizs = service.FindAll();
            }
            else
            {
                
                Quizs = service.FindByCat(Category);
            }

            ListQuizsCategoriesViewModel model = new ListQuizsCategoriesViewModel();
            model.Quizs = Quizs;
            model.Categories = Categories;

            return View(model);
        }
        public ActionResult Demarrer(int id)
        {
            Session["score"] = 0;
            Session["quizId"] = id;
            Session["order"] = 1;

            Question qst = service.FindQuestion( id, 1);


            return View("Quiz", qst);
        }
        [HttpPost]
        public ActionResult Next(FormCollection form)
        {
            int score = (int)Session["score"];
            int selectedQuizId = (int)Session["quizId"];
            int order = (int)Session["order"];

            Quiz qcm = service.FindById(selectedQuizId);
            Question qstEnCours = qcm.Questions[order - 1];

            if (!qstEnCours.IsMultiple)
            {
                int idSelectedRep = Convert.ToInt32(form.Get("selectedSimpleRep"));

                if (service.FindResponseById(idSelectedRep).IsCorrect)
                {
                    score++;
                    Session["score"] = score;
                }
                else
                {
                    score--;
                    Session["score"] = score;
                }
            }
            else
            {
                string[] reponses = form.GetValues("selectedRep[]");
                bool[] tabRep = new bool[reponses.Length];
                for (int i = 0; i < reponses.Length; i++)
                {
                    int idRepEnCours = Convert.ToInt32(reponses[i]);
                    tabRep[i] = service.FindResponseById(idRepEnCours).IsCorrect;
                }
                bool exist = tabRep.Contains(false);
                if (exist)
                {
                    score--;
                    Session["score"] = score;
                }
                else
                {
                    score++;
                    Session["score"] = score;
                }

            }

            //Passer à la question suivante
            if (order < qcm.Questions.Count)
            {
                order++;
                Session["order"] = order;
                Question qst = service.FindQuestion( selectedQuizId ,order);
                return View("Quiz", qst);
            }
            else
            {
                //Repmlir la table Historique
                //Envoyer le résultat par email
                return View("Result");
            }


        }
    }
}