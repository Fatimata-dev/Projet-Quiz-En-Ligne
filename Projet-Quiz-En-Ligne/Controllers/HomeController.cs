using Projet_Quiz_En_Ligne.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace Projet_Quiz_En_Ligne.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Index2()
        {
            return View();
        }
        public ActionResult Contact()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Contact(EmailModel model)
        {
            if (ModelState.IsValid)
            {
                using (MailMessage mm = new MailMessage(model.Email, model.To))
                {
                    mm.Subject = model.Subject;
                    mm.Body = model.Body;


                    mm.IsBodyHtml = false;
                    using (SmtpClient smtp = new SmtpClient())
                    {
                        smtp.Host = "smtp.gmail.com";
                        smtp.EnableSsl = true;
                        NetworkCredential cred = new NetworkCredential(model.Email, model.Password);
                        smtp.UseDefaultCredentials = true;
                        smtp.Credentials = cred;
                        smtp.Port = 587;
                        smtp.Send(mm);
                        ViewBag.message = "Message envoyé";

                    }
                }
                 return RedirectToAction("Index2");
            }
           
            return View();
            
        }
        //[HttpGet]
  
        //public ActionResult Logout()
        //{
        //    Session.Abandon();
        //    Session.RemoveAll();
        //    return RedirectToAction("Index");
          
        //}

    }
}