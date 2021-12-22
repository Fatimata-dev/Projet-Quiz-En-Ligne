using Projet_Quiz_En_Ligne.Models;
using Projet_Quiz_En_Ligne.Repositoriy;
using Projet_Quiz_En_Ligne.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
//using DBuserSignupLogin.Models;

namespace Projet_Quiz_En_Ligne.Controllers
{
    public class AdminController : Controller
    {
        private UserService service = new UserService(new UserRepository(new MyContext()));
        // GET: Admin
        public ActionResult IndexRegister()
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
            User u = service.GetUser(user.Email, user.Password);
            if(u != null)
            {
                ViewBag.Notification = "Ce compte existe deja";
                return View();

            }
            else
            {
                service.Insert(user);
              

               Session["IdUs"] = user.Id.ToString();
               Session["UsernameUs"] = user.Name.ToString();

                return RedirectToAction("IndexRegister", "Admin");
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
        public ActionResult Login(User user)
        {
            var checkLogin = service.GetUser(user.Email, user.Password);
                if(checkLogin != null)
            {
                Session["IdUs"] = user.Id.ToString();
                Session["UsernameUs"] = user.Name.ToString();
                return RedirectToAction("IndexRegister", "Admin");

            }
            else
            {
                ViewBag.Notification = "Mauvais nom d utilisateur ou mdp";
            }
            return View();
        }
    }
}