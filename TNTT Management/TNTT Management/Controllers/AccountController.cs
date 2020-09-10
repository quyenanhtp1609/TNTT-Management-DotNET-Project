using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TNTT_Management.Actions;

namespace TNTT_Management.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(string username,string password)
        {
            
            if (username == "tempacc123" && password == "123456")
            {
                Session["username"] = "temp";
            }
            else
            {
                return RedirectToAction("Login");
            }
            return RedirectToAction("ListStudent","Student");
        }

        public ActionResult Logout()
        {
            Session.Abandon();
            return RedirectToAction("Login");
        }
    }
}