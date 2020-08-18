using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TNTT_Management.Models;

namespace TNTT_Management.Actions
{
    public class ParishActions
    {
        public static List<LOCAL_PARISH> listParishes()
        {
            using (var db = new ChurchModel())
            {
                return db.LOCAL_PARISH.Where(m => m.isDeleted == false).ToList();
            }
        }

        public static USER_PARISH_ROLE findParishByUserID(int id)
        {
            using (var db = new ChurchModel())
            {

                return db.USER_PARISH_ROLE.Where(m => m.userid ==  id && m.isDeleted == false).FirstOrDefault();
            }
        }
    }
}