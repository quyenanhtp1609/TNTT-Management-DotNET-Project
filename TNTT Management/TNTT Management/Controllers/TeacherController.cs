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
            , DateTime? baptised_date, int? parishid, string parish, string diocese, string province)
        {
            if (parishid == null)
            {
                TeacherActions.addTeacher(holy_name, first_name, last_name, email
                , phone_number, gender, useradress, birthday, baptised_date, null,parish, diocese,  province);
            }
            else
            {
                TeacherActions.addTeacher(holy_name, first_name, last_name, email
              , phone_number, gender, useradress, birthday, baptised_date, (int)parishid
              , parish, diocese, province);
            }
            return RedirectToAction("ListTeacher");
        }


        public ActionResult EditTeacher(int id)
        {
            USERLOGIN user = TeacherActions.findTeacherByID(id);
            ViewBag.listParishes = ParishActions.listParishes();
            ViewBag.StudentByID = user;
            ViewBag.ListClassByTeacherID = ClassActions.findListClassByTeacherID(id);

            var liststudent_byclassid = StudentActions.findListStudentByClassID(id);
            if (liststudent_byclassid == null)
            {
                ViewBag.ListStudentByClassID = null;
            }
            else
            {
                ViewBag.ListStudentByClassID = liststudent_byclassid;
            }
            return View(ParishActions.findParishByUserID(user.userid));
        }

        [HttpPost]
        public ActionResult EditTeacherInfo(int id, string holy_name, string first_name, string last_name,
           string email, string phone_number, string gender, string useradress, DateTime? birthday,
           DateTime? baptised_date, int? parishid, string parish, string diocese, string province)
        {
            if (parishid != null)
            {
                TeacherActions.editTeacherInfo(id, holy_name, first_name, last_name,
         email, phone_number, gender, useradress, birthday,
         baptised_date, parishid, parish, diocese, province);
            }
            else
            {
                TeacherActions.editTeacherInfo(id, holy_name, first_name, last_name,
       email, phone_number, gender, useradress, birthday,
       baptised_date, null, parish, diocese, province);
            }

            return RedirectToAction("EditTeacher", "Teacher", new { id });
        }

        public ActionResult ListTeacher()
        {
            if (Session["username"] != null)
            {
                ViewBag.ListTeacher = TeacherActions.listTeachers();
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
          
            return View();
        }

        public ActionResult DeletedTeacher(int id)
        {
            TeacherActions.deleted_teacher(id);
            return RedirectToAction("ListTeacher");
        }

    }
}