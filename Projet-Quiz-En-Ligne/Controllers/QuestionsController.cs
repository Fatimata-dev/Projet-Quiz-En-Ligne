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
    public class QuestionsController : Controller
    {
        private QuestionService questionService = new QuestionService(new QuestionRepository(new MyContext()));
        private QuizService qzservice = new QuizService(new QuizRepository(new MyContext()));

        // GET: QuizQuestions
        public ActionResult Index()
        {
            List<Question> questions = questionService.FindAll();
            return View(questions);
        }

        // GET: QuizQuestions/Details/5
        public ActionResult Details(int id)
        {
            Question question = questionService.FindById(id);
            if (question == null)
            {
                return HttpNotFound();
            }
            return View(question);
        }

        // GET: QuizQuestions/Create
        public ActionResult Create()
        {
            ViewBag.QuizId = new SelectList(qzservice.FindAll(), "Id", "Sujet");
            return View(new Question());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,QstText,IsMultiple,NumOrder,QuizId")] Question question)
        {
            if (ModelState.IsValid)
            {
                questionService.Insert(question);
                return RedirectToAction("Index");
            }
            ViewBag.QuizId = new SelectList(qzservice.FindAll(), "Id", "Sujet", question.QuizId);
            return View(question);
        }

        // GET: QuizQuestions/Edit/5
        public ActionResult Edit(int id)
        {
            Question question = questionService.FindById(id);
            if (question == null)
            {
                return HttpNotFound();
            }
            ViewBag.QuizId = new SelectList(qzservice.FindAll(), "Id", "Sujet", question.QuizId);
            return View(question);
        }

      
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,QstText,IsMultiple,NumOrder,QuizId")] Question question)
        {
            if (ModelState.IsValid)
            {
                questionService.Update(question);
                return RedirectToAction("Index");
            }
            ViewBag.QuizId = new SelectList(questionService.FindAll(), "Id", "Sujet", question.QuizId);
            return View(question);
        }

        // GET: QuizQuestions/Delete/5
        public ActionResult Delete(int id)
        {
            Question quizQuestion = questionService.FindById(id);
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
            questionService.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
