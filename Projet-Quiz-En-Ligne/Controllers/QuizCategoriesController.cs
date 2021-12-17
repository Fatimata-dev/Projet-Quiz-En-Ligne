﻿using System;
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
    public class QuizCategoriesController : Controller
    {
        private CategoryService db = new CategoryService(new CategoryRepository(new MyContext()));

        // GET: QuizCategories
        public ActionResult Index()
        {
            List<QuizCategory> categories = db.FindAll();
            return View(categories);
        }

        // GET: QuizCategories/Details/5
        public ActionResult Details(int id)
        {
            QuizCategory quizCategory = db.FindById(id);
            if (quizCategory == null)
            {
                return HttpNotFound();
            }
            return View(quizCategory);
        }

        // GET: QuizCategories/Create
        public ActionResult Create()
        {
            return View(new QuizCategory() );
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name")] QuizCategory quizCategory)
        {
            if (ModelState.IsValid)
            {
                db.Insert(quizCategory);
                return RedirectToAction("Index");
            }

            return View(quizCategory);
        }

        // GET: QuizCategories/Edit/5
        public ActionResult Edit(int id)
        {
            QuizCategory quizCategory = db.FindById(id);
            if (quizCategory == null)
            {
                return HttpNotFound();
            }
            return View(quizCategory);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name")] QuizCategory quizCategory)
        {
            if (ModelState.IsValid)
            {
                db.Update(quizCategory);
                return RedirectToAction("Index");
            }
            return View(quizCategory);
        }

        // GET: QuizCategories/Delete/5
        public ActionResult Delete(int id)
        {
            QuizCategory quizCategory = db.FindById(id);
            if (quizCategory == null)
            {
                return HttpNotFound();
            }
            return View(quizCategory);
        }

        // POST: QuizCategories/Delete/5
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