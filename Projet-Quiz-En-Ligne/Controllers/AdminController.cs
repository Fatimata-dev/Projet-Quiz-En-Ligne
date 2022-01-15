using Projet_Quiz_En_Ligne.Models;
using Projet_Quiz_En_Ligne.Repositories;
using Projet_Quiz_En_Ligne.Services;
using Projet_Quiz_En_Ligne.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Projet_Quiz_En_Ligne.Controllers
{
    public class AdminController : Controller
    {
        private UserService service = new UserService(new UserRepository(new MyContext()));
        // GET: Admin
        public ActionResult Index()
        {

            return View(service.FindAll());
        }

        public ActionResult Signup()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Signup(UserResultViewModel userVm)
        {
            //UserResultViewModel u = service.GetUser(userVm);
            if (ModelState.IsValid)
            {
                userVm.quiz = null;
                userVm.resultat = null;
                    service.Insert(userVm);
                    return RedirectToAction("Login", "Admin");
            }
            else
            {
                return View(userVm);
            }


        }
        public ActionResult Logout()
        {
            Session.Clear();

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public ActionResult Login()
        {

            return View();
        }
        [HttpPost]
        public ActionResult Login(UserResultViewModel user)
        {
            if (user != null)
            {
                    Session["User"] = user;
                    return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.Notification = "Mauvais nom d utilisateur ou mdp";
            }
            return View();
        }

       
    }
}