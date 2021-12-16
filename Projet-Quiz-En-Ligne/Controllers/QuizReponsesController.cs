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
    public class QuizReponsesController : Controller
    {
        private ReponseService db = new ReponseService(new ReponseRepository(new MyContext()));

        // GET: QuizReponses
        public ActionResult Index()
        {
            //.Include(q => q.Question)
            var quizReponses = db.FindAll();
            return View(quizReponses);
        }

        // GET: QuizReponses/Details/5
        public ActionResult Details(int id)
        {
            QuizReponse quizReponse = db.GetById(id);
            if (quizReponse == null)
            {
                return HttpNotFound();
            }
            return View(quizReponse);
        }

        // GET: QuizReponses/Create
        public ActionResult Create()
        {
            ViewBag.QuestionId = new SelectList(db.FindAll(), "Id", "QstText");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,RespText,IsCorrect,QuestionId")] QuizReponse quizReponse)
        {
            if (ModelState.IsValid)
            {
                db.Insert(quizReponse);
                return RedirectToAction("Index");
            }

            ViewBag.QuestionId = new SelectList(db.FindAll(), "Id", "QstText", quizReponse.QuestionId);
            return View(quizReponse);
        }

        // GET: QuizReponses/Edit/5
        public ActionResult Edit(int id)
        {
            QuizReponse quizReponse = db.GetById(id);
            if (quizReponse == null)
            {
                return HttpNotFound();
            }
            ViewBag.QuestionId = new SelectList(db.FindAll(), "Id", "QstText", quizReponse.QuestionId);
            return View(quizReponse);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,RespText,IsCorrect,QuestionId")] QuizReponse quizReponse)
        {
            if (ModelState.IsValid)
            {
                db.Update(quizReponse);
                return RedirectToAction("Index");
            }
            ViewBag.QuestionId = new SelectList(db.FindAll(), "Id", "QstText", quizReponse.QuestionId);
            return View(quizReponse);
        }

        // GET: QuizReponses/Delete/5
        public ActionResult Delete(int id)
        {
            QuizReponse quizReponse = db.GetById(id);
            if (quizReponse == null)
            {
                return HttpNotFound();
            }
            return View(quizReponse);
        }

        // POST: QuizReponses/Delete/5
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
