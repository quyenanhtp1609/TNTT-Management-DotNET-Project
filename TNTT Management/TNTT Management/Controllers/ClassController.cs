using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TNTT_Management.Actions;

namespace TNTT_Management.Controllers
{
    public class ClassController : Controller
    {
        // GET: Class
        public ActionResult AddCLass()
        {
            ViewBag.ListGroups = GroupActions.listGroups();
            ViewBag.ListTeachers = TeacherActions.listTeachers();
            ViewBag.ListClasses = ClassActions.listClasses();
            return View();
        }
        [HttpPost]
        public ActionResult AddCLass(string class_name, string note, int? form_teacher_id, int? group_id)
        {
            ClassActions.addClass(class_name, note, form_teacher_id, group_id);
            return RedirectToAction("Addclass");
        }

        public ActionResult EditClass(int id)
        {
            var classbyid = ClassActions.findClassByID(id);
            ViewBag.Class = classbyid;
            ViewBag.ListGroups = GroupActions.listGroups();
            ViewBag.ListTeachers = TeacherActions.listTeachers();
            return View(classbyid);
        }
        [HttpPost]
        public ActionResult EditClass(int id, string class_name, string note
         , int? form_teacher_id, int? group_id)
        {
            ClassActions.editClass(id,  class_name, note
         , form_teacher_id, group_id);
            return RedirectToAction("AddClass");
        }

        public ActionResult DeleteClass(int id)
        {
            ClassActions.deleteClass(id);
            return RedirectToAction("AddClass");
        }
    }
}