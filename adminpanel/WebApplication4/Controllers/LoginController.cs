using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication4.Models;

namespace WebApplication4.Controllers
{
    public class LoginController : Controller
    {
        ManagmentSystemEntities db = new ManagmentSystemEntities();
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(string email,string password)
        {
            var user = db.Users.FirstOrDefault(x=>x.email.Equals(email) && x.password.Equals(password));
            if(user!=null)
            {
                Session["userid"] = user.id;
                Session["username"] = user.name;
                Session["useremail"] = user.email;
                return RedirectToAction("Index","Admin");

            }
            else
            {
                return RedirectToAction("Index");
            }
            
        }
    }
}