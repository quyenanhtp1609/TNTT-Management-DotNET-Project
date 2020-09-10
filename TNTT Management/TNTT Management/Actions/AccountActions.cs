using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TNTT_Management.Models;

namespace TNTT_Management.Actions
{
    public class AccountActions
    {
        public static USERLOGIN check_Login(string username,string password)
        {
            using (var db = new ChurchModel())
            {
                return db.USERLOGINs.Where(m => m.username == username && m.userpassword == password).FirstOrDefault();
            }
        }
    }
}