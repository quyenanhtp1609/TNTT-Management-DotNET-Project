using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TNTT_Management.Actions;
using TNTT_Management.Models;

namespace TNTT_Management.Controllers
{
    public class TeacherController : Controller
    {
        // GET: Teacher
        public ActionResult AddTeacher()
        {
            ViewBag.listParishes = ParishActions.listParishes();
            return View();
        }

        [HttpPost]
        public ActionResult AddTeacher(string holy_name, string first_name, string last_name, string email
         , string phone_number, string gender, string useradress, DateTime? birthday
            , DateTime? baptised_date, int? parishid)
        {
            if (parishid == null)
            {
                TeacherActions.addTeacher(holy_name, first_name, last_name, email
                , phone_number, gender, useradress, birthday, baptised_date, null);
            }
            else
            {
                TeacherActions.addTeacher(holy_name, first_name, last_name, email
              , phone_number, gender, useradress, birthday, baptised_date, (int)parishid);
            }
            return RedirectToAction("ListTeacher");
        }


        public ActionResult EditTeacher(int id)
        {
            USERLOGIN user = TeacherActions.findTeacherByID(id);
            ViewBag.listParishes = ParishActions.listParishes();
            ViewBag.StudentByID = user;
            return View(ParishActions.findParishByUserID(user.userid));
        }

        [HttpPost]
        public ActionResult EditTeacherInfo(int id, string holy_name, string first_name, string last_name,
           string email, string phone_number, string gender, string useradress, DateTime? birthday,
           DateTime? baptised_date, int? parishid)
        {
            if (parishid != null)
            {
                TeacherActions.editTeacherInfo(id, holy_name, first_name, last_name,
         email, phone_number, gender, useradress, birthday,
         baptised_date, parishid);
            }
            else
            {
                TeacherActions.editTeacherInfo(id, holy_name, first_name, last_name,
       email, phone_number, gender, useradress, birthday,
       baptised_date, null);
            }

            return RedirectToAction("EditTeacher", "Teacher", new { id });
        }

        public ActionResult ListTeacher()
        {
            ViewBag.ListTeacher = TeacherActions.listTeachers();
            return View();
        }

        public ActionResult DeletedTeacher(int id)
        {
            TeacherActions.deleted_teacher(id);
            return RedirectToAction("ListTeacher");
        }

    }
}