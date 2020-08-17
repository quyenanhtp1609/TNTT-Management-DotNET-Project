using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TNTT_Management.Actions;

namespace TNTT_Management.Controllers
{
    public class TeacherController : Controller
    {
        // GET: Teacher
        public ActionResult AddTeacher()
        {
            return View();
        }

        public ActionResult EditTeacher()
        {
            return View();
        }

        public ActionResult ListTeacher()
        {
            ViewBag.ListTeacher = TeacherActions.listTeachers();
            return View();
        }
    }
}