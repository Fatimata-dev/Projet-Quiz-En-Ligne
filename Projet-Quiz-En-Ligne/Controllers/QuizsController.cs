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
    public class QuizsController : Controller
    {
        private QuizService db = new QuizService(new QuizRepository(new MyContext()));

        // GET: Quizs
        public ActionResult Index()
        {
           List<Quiz> quiz = db.FindAll();
            return View(quiz);
        }

        // GET: Quizs/Details/5
        public ActionResult Details(int id)
        {
            Quiz quiz = db.FindById(id);
            
            if (quiz == null)
            {
                return HttpNotFound();
            }
            return View(quiz);
        }

        // GET: Quizs/Create
        public ActionResult Create()
        {
            return View(new Quiz());
        }

        // POST: Quizs/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Quiz quiz)
        {
            if (ModelState.IsValid)
            {
                db.Insert(quiz);
                return RedirectToAction("Index");
            }

            return View(quiz);
        }

        // GET: Quizs/Edit/5
        public ActionResult Edit(int id)
        {
            Quiz quiz = db.FindById(id);
            if (quiz == null)
            {
                return HttpNotFound();
            }
            return View(quiz);
        } [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Sujet,Image,Category")] Quiz quiz)
        {
            if (ModelState.IsValid)
            {
                db.Update(quiz);
                return RedirectToAction("Index");
            }
            return View(quiz);
        }

        // GET: Quizs/Delete/5
        public ActionResult Delete(int id)
        {
            Quiz quiz = db.FindById(id);
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
            db.DeleteById(id);
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
