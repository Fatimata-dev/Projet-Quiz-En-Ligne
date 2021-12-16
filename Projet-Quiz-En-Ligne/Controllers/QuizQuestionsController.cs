using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Projet_Quiz_En_Ligne.Models;
using Projet_Quiz_En_Ligne.Repositories;
using Projet_Quiz_En_Ligne.Services;

namespace Projet_Quiz_En_Ligne.Controllers
{
    public class QuizQuestionsController : Controller
    {
        private QuizQuestionService db = new QuizQuestionService(new QuizQuestionRepository(new MyContext()));
        private QuizService qzservice = new QuizService(new QuizRepository(new MyContext()));

        // GET: QuizQuestions
        public ActionResult Index()
        {
            List<QuizQuestion> questions = db.FindAll();
            return View(questions);
        }

        // GET: QuizQuestions/Details/5
        public ActionResult Details(int id)
        {
            QuizQuestion quizQuestion = db.FindById(id);
            if (quizQuestion == null)
            {
                return HttpNotFound();
            }
            return View(quizQuestion);
        }

        // GET: QuizQuestions/Create
        public ActionResult Create()
        {
            ViewBag.QuizId = new SelectList(qzservice.FindAll(), "Id", "Sujet");
            return View(new QuizQuestion());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,QstText,IsMultiple,NumOrder,QuizId")] QuizQuestion quizQuestion)
        {
            if (ModelState.IsValid)
            {
                db.Insert(quizQuestion);
                return RedirectToAction("Index");
            }
            ViewBag.QuizId = new SelectList(qzservice.FindAll(), "Id", "Sujet", quizQuestion.QuizId);
            return View(quizQuestion);
        }

        // GET: QuizQuestions/Edit/5
        public ActionResult Edit(int id)
        {
            QuizQuestion quizQuestion = db.FindById(id);
            if (quizQuestion == null)
            {
                return HttpNotFound();
            }
            ViewBag.QuizId = new SelectList(qzservice.FindAll(), "Id", "Sujet", quizQuestion.QuizId);
            return View(quizQuestion);
        }

      
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,QstText,IsMultiple,NumOrder,QuizId")] QuizQuestion quizQuestion)
        {
            if (ModelState.IsValid)
            {
                db.Update(quizQuestion);
                return RedirectToAction("Index");
            }
            ViewBag.QuizId = new SelectList(db.FindAll(), "Id", "Sujet", quizQuestion.QuizId);
            return View(quizQuestion);
        }

        // GET: QuizQuestions/Delete/5
        public ActionResult Delete(int id)
        {
            QuizQuestion quizQuestion = db.FindById(id);
            if (quizQuestion == null)
            {
                return HttpNotFound();
            }
            return View(quizQuestion);
        }

        // POST: QuizQuestions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            db.Delete(id);
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
