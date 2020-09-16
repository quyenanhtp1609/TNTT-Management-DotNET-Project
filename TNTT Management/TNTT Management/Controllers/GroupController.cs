using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TNTT_Management.Actions;

namespace TNTT_Management.Controllers
{
    public class GroupController : Controller
    {
        // GET: Group
        public ActionResult AddGroup()
        {
            ViewBag.listParishes = ParishActions.listParishes();
            ViewBag.listGroups = GroupActions.listGroups();

            return View();
        }
        [HttpPost]
        public ActionResult AddGroup(string group_name, string note, int? parishid)
        {
            GroupActions.addGroup(group_name, note, parishid);
            return RedirectToAction("AddGroup");
        }

        public ActionResult EditGroup(int id)
        {
            ViewBag.listParishes = ParishActions.listParishes();
            ViewBag.Group = GroupActions.findGroupByID(id);
            return View();
        }
        [HttpPost]
        public ActionResult EditGroup(int id, string group_name, string note
            , int? parish_id)
        {
            GroupActions.editGroup(id, group_name, note, parish_id);
            return RedirectToAction("AddGroup");
        }

        public ActionResult DeleteGroup(int id)
        {
            GroupActions.deleteGroup(id);
            return RedirectToAction("AddGroup");
        }
    }
}