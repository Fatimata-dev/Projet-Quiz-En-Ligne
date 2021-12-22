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
    public class ReponsesController : Controller
    {
        private ReponseService reponseService = new ReponseService(new ReponseRepository(new MyContext()));
        private QuestionService service = new QuestionService(new QuestionRepository(new MyContext()));

        // GET: QuizReponses
        public ActionResult Index(int page = 0)
        {
            var quizReponses = reponseService.FindAll();
            int pageSize = 4;
            page = (page < 0) ? 0 : page; //opérateur ternaire

            ViewBag.PreviousPage = page - 1;
            ViewBag.NextPage = page + 1;
            ViewBag.Page = page + 1;
            int pagesTotales = 0;
            if ((quizReponses.Count % pageSize) == 0)
            {
                pagesTotales = quizReponses.Count / pageSize;
            }
            else
            {
                pagesTotales = (quizReponses.Count / pageSize) + 1;
            }

            ViewBag.Totales = pagesTotales;

            quizReponses = quizReponses.Skip(page * pageSize).Take(pageSize).ToList();

            if (quizReponses.Count < pageSize)
            {
                ViewBag.NextPage = page;
            }
            else
            {
                ViewBag.NextPage = page + 1;
            }

            return View(quizReponses);
        }

        // GET: QuizReponses/Details/5
        public ActionResult Details(int id)
        {
            Reponse quizReponse = reponseService.GetById(id);
            if (quizReponse == null)
            {
                return HttpNotFound();
            }
            return View(quizReponse);
        }

        // GET: QuizReponses/Create
        public ActionResult Create()
        {
            ViewBag.QuestionId = new SelectList(service.FindAll(), "Id", "QstText");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,RespText,IsCorrect,QuestionId")] Reponse reponse)
        {
            if (ModelState.IsValid)
            {
                reponseService.Insert(reponse);
                return RedirectToAction("Index");
            }

            ViewBag.QuestionId = new SelectList(service.FindAll(), "Id", "QstText", reponse.QuestionId);
            return View(reponse);
        }

        // GET: QuizReponses/Edit/5
        public ActionResult Edit(int id)
        {
            Reponse reponse = reponseService.GetById(id);
            if (reponse == null)
            {
                return HttpNotFound();
            }
            ViewBag.QuestionId = new SelectList(service.FindAll(), "Id", "QstText", reponse.QuestionId);
            return View(reponse);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,RespText,IsCorrect,QuestionId")] Reponse quizReponse)
        {
            if (ModelState.IsValid)
            {
                reponseService.Update(quizReponse);
                return RedirectToAction("Index");
            }
            ViewBag.QuestionId = new SelectList(service.FindAll(), "Id", "QstText", quizReponse.QuestionId);
            return View(quizReponse);
        }

        // GET: QuizReponses/Delete/5
        public ActionResult Delete(int id)
        {
            Reponse quizReponse = reponseService.GetById(id);
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
            reponseService.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
