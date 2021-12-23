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
        public ActionResult Signup(User user)
        {
            //User u = service.GetUser(user);
            if (user != null)
            {
                ViewBag.Notification = "Ce compte existe deja";
                return View();

            }
            else
            {

                service.Insert(user);
                if (user.IsAdmin)
                {
                    Session["Admin"] = user;
                    return RedirectToAction("Index", "Admin");
                }
                else
                {
                    Session["User"] = user;
                    return RedirectToAction("Index", "Home");
                }


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
        [ValidateAntiForgeryToken]
        public ActionResult Login(UserResultViewModel user)
        {
            if (user != null)
            {
                if (user.IsAdmin)
                {
                    Session["Admin"] = user;
                    //Session["AdminName"] = user.Name.ToString();
                    return RedirectToAction("Index", "Admin");
                }
                else
                {
                    Session["User"] = user;
                    //Session["UserName"] = user.Name.ToString();
                    return RedirectToAction("Index", "Home");
                }


            }
            else
            {

                ViewBag.Notification = "Mauvais nom d utilisateur ou mdp";
            }
            return View();
        }
    }
}