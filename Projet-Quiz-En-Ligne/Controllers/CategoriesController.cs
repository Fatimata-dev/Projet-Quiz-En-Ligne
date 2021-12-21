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
    public class CategoriesController : Controller
    {
        private CategoryService categoryService = new CategoryService(new CategoryRepository(new MyContext()));

        // GET: QuizCategories
        public ActionResult Index()
        {
            List<Category> categories = categoryService.FindAll();
            return View(categories);
        }

        // GET: QuizCategories/Details/5
        public ActionResult Details(int id)
        {
            Category quizCategory = categoryService.FindById(id);
            if (quizCategory == null)
            {
                return HttpNotFound();
            }
            return View(quizCategory);
        }

        // GET: QuizCategories/Create
        public ActionResult Create()
        {
            return View(new Category() );
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name")] Category quizCategory)
        {
            if (ModelState.IsValid)
            {
                categoryService.Insert(quizCategory);
                return RedirectToAction("Index");
            }

            return View(quizCategory);
        }

        // GET: QuizCategories/Edit/5
        public ActionResult Edit(int id)
        {
            Category quizCategory = categoryService.FindById(id);
            if (quizCategory == null)
            {
                return HttpNotFound();
            }
            return View(quizCategory);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name")] Category quizCategory)
        {
            if (ModelState.IsValid)
            {
                categoryService.Update(quizCategory);
                return RedirectToAction("Index");
            }
            return View(quizCategory);
        }

        // GET: QuizCategories/Delete/5
        public ActionResult Delete(int id)
        {
            Category quizCategory = categoryService.FindById(id);
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
            categoryService.DeleteById(id);
            return RedirectToAction("Index");
        }

    }
}
