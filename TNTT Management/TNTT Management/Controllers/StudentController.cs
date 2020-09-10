using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TNTT_Management.Actions;
using TNTT_Management.Models;

namespace TNTT_Management.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        public ActionResult AddStudent()
        {
            ViewBag.listParishes = ParishActions.listParishes();
            return View();
        }
        [HttpPost]
        public ActionResult AddStudent(string holy_name, string first_name, string last_name, string email
            , string phone_number, string gender, string useradress, DateTime? birthday, DateTime? baptised_date, int? parishid,
            string father_name, string father_phone_number, string mother_name, string mother_phone_number)
        {
            if (parishid == null)
            {
                StudentActions.addStudent(holy_name, first_name, last_name, email
                , phone_number, gender, useradress, birthday, baptised_date, null,
                father_name, father_phone_number, mother_name, mother_phone_number);
            }
            else
            {
                StudentActions.addStudent(holy_name, first_name, last_name, email
              , phone_number, gender, useradress, birthday, baptised_date, (int)parishid,
              father_name, father_phone_number, mother_name, mother_phone_number);
            }
            return RedirectToAction("ListStudent");
        }

        public ActionResult EditStudent(int id)
        {
            USERLOGIN user = StudentActions.findStudentByID(id);
            ViewBag.listParishes = ParishActions.listParishes();
            ViewBag.StudentByID = user;
            return View(ParishActions.findParishByUserID(user.userid));
        }
        [HttpPost]
        public ActionResult EditStudentInfo(int id, string holy_name, string first_name, string last_name,
            string email, string phone_number, string gender, string useradress, DateTime? birthday,
            DateTime? baptised_date, int? parishid)
        {
            if (parishid != null)
            {
                StudentActions.editStudentinfo(id, holy_name, first_name, last_name,
         email, phone_number, gender, useradress, birthday,
         baptised_date, parishid);
            }
            else
            {
                StudentActions.editStudentinfo(id, holy_name, first_name, last_name,
       email, phone_number, gender, useradress, birthday,
       baptised_date, null);
            }

            return RedirectToAction("EditStudent", "Student", new { id });
        }
        [HttpPost]
        public ActionResult EditStudentSacramental(int id, string baptised_place, DateTime? baptised_date
            , string first_communion_place, DateTime? first_communion_date, string confirmation_place, DateTime? confirmation_date)
        {
            StudentActions.editStudentSacramental(id, baptised_place, baptised_date
            , first_communion_place, first_communion_date, confirmation_place, confirmation_date);
            return RedirectToAction("EditStudent", "Student", new { id });
        }
        [HttpPost]
        public ActionResult EditStudentParentInfo(int id, string father_name, string father_phone_number, string mother_name,
            string mother_phone_number)
        {
            StudentActions.editStudent_parentInfo(id, father_name, father_phone_number, mother_name,
             mother_phone_number);
            return RedirectToAction("EditStudent", "Student", new { id });
        }

        public ActionResult DeletedStudent(int id)
        {
            StudentActions.deleted_student(id);
            return RedirectToAction("ListStudent");
        }

        public ActionResult ListStudent()
        {
            if (Session["username"] != null)
            {
                ViewBag.ListStudent = StudentActions.listStudents();
            }
            else
            {
                return RedirectToAction("Login","Account");
            }
            return View();
        }
    }
}