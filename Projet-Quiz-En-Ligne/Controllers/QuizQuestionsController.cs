using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Projet_Quiz_En_Ligne.Models;

namespace Projet_Quiz_En_Ligne.Controllers
{
    public class QuizQuestionsController : Controller
    {
        private MyContext db = new MyContext();

        // GET: QuizQuestions
        public ActionResult Index()
        {
            var quizQuestions = db.QuizQuestions.Include(q => q.Quiz);
            return View(quizQuestions.ToList());
        }

        // GET: QuizQuestions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            QuizQuestion quizQuestion = db.QuizQuestions.Find(id);
            if (quizQuestion == null)
            {
                return HttpNotFound();
            }
            return View(quizQuestion);
        }

        // GET: QuizQuestions/Create
        public ActionResult Create()
        {
            ViewBag.QuizId = new SelectList(db.Quizzes, "Id", "Sujet");
            return View();
        }

        // POST: QuizQuestions/Create
        // Pour vous protéger des attaques par survalidation, activez les propriétés spécifiques auxquelles vous souhaitez vous lier. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,QstText,IsMultiple,NumOrder,QuizId")] QuizQuestion quizQuestion)
        {
            if (ModelState.IsValid)
            {
                db.QuizQuestions.Add(quizQuestion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.QuizId = new SelectList(db.Quizzes, "Id", "Sujet", quizQuestion.QuizId);
            return View(quizQuestion);
        }

        // GET: QuizQuestions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            QuizQuestion quizQuestion = db.QuizQuestions.Find(id);
            if (quizQuestion == null)
            {
                return HttpNotFound();
            }
            ViewBag.QuizId = new SelectList(db.Quizzes, "Id", "Sujet", quizQuestion.QuizId);
            return View(quizQuestion);
        }

        // POST: QuizQuestions/Edit/5
        // Pour vous protéger des attaques par survalidation, activez les propriétés spécifiques auxquelles vous souhaitez vous lier. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,QstText,IsMultiple,NumOrder,QuizId")] QuizQuestion quizQuestion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(quizQuestion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.QuizId = new SelectList(db.Quizzes, "Id", "Sujet", quizQuestion.QuizId);
            return View(quizQuestion);
        }

        // GET: QuizQuestions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            QuizQuestion quizQuestion = db.QuizQuestions.Find(id);
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
            QuizQuestion quizQuestion = db.QuizQuestions.Find(id);
            db.QuizQuestions.Remove(quizQuestion);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
