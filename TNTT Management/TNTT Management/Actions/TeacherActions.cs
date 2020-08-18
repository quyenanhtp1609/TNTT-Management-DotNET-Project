using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TNTT_Management.Models;

namespace TNTT_Management.Actions
{
    public class TeacherActions
    {
        public static List<USERLOGIN> listTeachers()
        {
            using (var db = new ChurchModel())
            {
                return db.USERLOGINs.Where(m => m.isDeleted == false).ToList();
            }
        }
    }
}