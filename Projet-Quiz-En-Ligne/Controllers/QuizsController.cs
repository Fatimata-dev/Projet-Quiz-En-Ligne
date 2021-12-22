using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Projet_Quiz_En_Ligne.Models;
using Projet_Quiz_En_Ligne.Repositories;
using Projet_Quiz_En_Ligne.Services;
using Projet_Quiz_En_Ligne.ViewModel;

namespace Projet_Quiz_En_Ligne.Controllers
{
    public class QuizsController : Controller
    {
        private QuizService quizService = new QuizService(new QuizRepository(new MyContext()));
        private CategoryService category = new CategoryService(new CategoryRepository(new MyContext()));

        // GET: Quizs
        public ActionResult Index()
        {
           List<Quiz> quiz = quizService.FindAll();
            return View(quiz);
        }

        // GET: Quizs/Details/5
        public ActionResult Details(int id)
        {
            Quiz quiz = quizService.FindById(id);
            
            if (quiz == null)
            {
                return HttpNotFound();
            }
            return View(quiz);
        }

        // GET: Quizs/Create

        public ActionResult Create()
        {
            QuizCategoryViewModel model = new QuizCategoryViewModel();
            model.Quiz = new Quiz();
            model.Categories = category.FindAll();
            return View(model);
        }

        // POST: Quizs/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Sujet,Category,Image")] Quiz quiz, HttpPostedFileBase Image)
        {
            if (ModelState.IsValid)
            {
                quiz.Image = (quiz.Sujet) + Path.GetExtension(Image.FileName);
                Image.SaveAs(Server.MapPath("~/Content/Images/") + quiz.Image);
                quizService.Insert(quiz);
                return RedirectToAction("Index");
            }

            return View(quiz);
        }

        // GET: Quizs/Edit/5
        public ActionResult Edit(int id )
        {   
            Quiz quiz = quizService.FindById(id);
            if (quiz == null)
            {
                return HttpNotFound();
            }
            else
            {
                QuizCategoryViewModel model = new QuizCategoryViewModel();
                model.Quiz = quiz;
                Session["Image"] = quiz.Image; 
                model.Categories = category.FindAll();
                return View(model);
            }
            
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Quiz quiz , HttpPostedFileBase Image)
        {
            if (!ModelState.IsValid)
            {
                return View(quiz);

            }
            else
            {
                if (Image != null)
                {
                    quiz.Image = quiz.Sujet + Path.GetExtension(Image.FileName);
                    Image.SaveAs(Server.MapPath("~/Content/Images/") + quiz.Image);
                }
                else
                {
                    quiz.Image = (string)Session["Image"];
                }
                quizService.Update(quiz);
                return RedirectToAction("Index");
            }
            
        }

        // GET: Quizs/Delete/5
        public ActionResult Delete(int id)
        {
            Quiz quiz = quizService.FindById(id);
            if (quiz == null)
            {
                return HttpNotFound();
            }
            return View(quiz);
        }

        // POST: Quizs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            quizService.DeleteById(id);
            return RedirectToAction("Index");
        }

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}
    }
}
