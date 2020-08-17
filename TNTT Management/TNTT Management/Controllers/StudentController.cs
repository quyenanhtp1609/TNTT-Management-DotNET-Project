using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TNTT_Management.Actions;

namespace TNTT_Management.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        public ActionResult AddStudent()
        {
            return View();
        }

        public ActionResult EditStudent()
        {
            return View();
        }

        public ActionResult ListStudent()
        {
            ViewBag.ListStudent = StudentActions.listStudents();
            return View();
        }
    }
}