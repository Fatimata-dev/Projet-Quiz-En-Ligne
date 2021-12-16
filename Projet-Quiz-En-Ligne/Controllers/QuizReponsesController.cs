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
    public class QuizReponsesController : Controller
    {
        private MyContext db = new MyContext();

        // GET: QuizReponses
        public ActionResult Index()
        {
            var quizReponses = db.QuizReponses.Include(q => q.Question);
            return View(quizReponses.ToList());
        }

        // GET: QuizReponses/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            QuizReponse quizReponse = db.QuizReponses.Find(id);
            if (quizReponse == null)
            {
                return HttpNotFound();
            }
            return View(quizReponse);
        }

        // GET: QuizReponses/Create
        public ActionResult Create()
        {
            ViewBag.QuestionId = new SelectList(db.QuizQuestions, "Id", "QstText");
            return View();
        }

        // POST: QuizReponses/Create
        // Pour vous protéger des attaques par survalidation, activez les propriétés spécifiques auxquelles vous souhaitez vous lier. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,RespText,IsCorrect,QuestionId")] QuizReponse quizReponse)
        {
            if (ModelState.IsValid)
            {
                db.QuizReponses.Add(quizReponse);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.QuestionId = new SelectList(db.QuizQuestions, "Id", "QstText", quizReponse.QuestionId);
            return View(quizReponse);
        }

        // GET: QuizReponses/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            QuizReponse quizReponse = db.QuizReponses.Find(id);
            if (quizReponse == null)
            {
                return HttpNotFound();
            }
            ViewBag.QuestionId = new SelectList(db.QuizQuestions, "Id", "QstText", quizReponse.QuestionId);
            return View(quizReponse);
        }

        // POST: QuizReponses/Edit/5
        // Pour vous protéger des attaques par survalidation, activez les propriétés spécifiques auxquelles vous souhaitez vous lier. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,RespText,IsCorrect,QuestionId")] QuizReponse quizReponse)
        {
            if (ModelState.IsValid)
            {
                db.Entry(quizReponse).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.QuestionId = new SelectList(db.QuizQuestions, "Id", "QstText", quizReponse.QuestionId);
            return View(quizReponse);
        }

        // GET: QuizReponses/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            QuizReponse quizReponse = db.QuizReponses.Find(id);
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
            QuizReponse quizReponse = db.QuizReponses.Find(id);
            db.QuizReponses.Remove(quizReponse);
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
