using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading;
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

        public static void addTeacher(string holy_name, string first_name, string last_name, string email
         , string phone_number, string gender, string useradress, DateTime? birthday
            , DateTime? baptised_date, int? parish_id)
        {
            using (var db = new ChurchModel())
            {

                int count_user = db.USERLOGINs.Count();
                int count_user_parish = db.USER_PARISH_ROLE.Count();

                USERLOGIN new_user = new USERLOGIN
                {
                    userid = count_user + 1,
                    holy_name = holy_name,
                    first_name = first_name,
                    last_name = last_name,
                    email = email,
                    phone_number = phone_number,
                    gender = gender,
                    useradress = useradress,
                    birthday = birthday,
                    baptised_date = baptised_date,
                    isDeleted = false,
                    username = last_name + count_user.ToString(),
                    userpassword = last_name + count_user.ToString() + "@123"
                };
                db.USERLOGINs.Add(new_user);
                db.SaveChanges();
                Thread.Sleep(200);
                if (parish_id != null)
                {
                    db.USER_PARISH_ROLE.Add(new USER_PARISH_ROLE
                    {
                        USER_PARISH_ROLE_ID = count_user_parish + 1,
                        roleid = 2,
                        userid = new_user.userid,
                        parishid = parish_id
                        ,
                        isDeleted = false
                    });
                    db.SaveChanges();
                }
                db.Dispose();
            }
        }

        public static USERLOGIN findTeacherByID(int id)
        {
            using (var db = new ChurchModel())
            {
                return db.USERLOGINs.Where(m => m.userid == id && m.isDeleted == false).FirstOrDefault();
            }
        }

        public static void editTeacherInfo(int id, string holy_name, string first_name, string last_name,
         string email, string phone_number, string gender, string useradress, DateTime? birthday,
         DateTime? baptised_date, int? parish_id)
        {
            using (var db = new ChurchModel())
            {
                int count_user_parish = db.USER_PARISH_ROLE.Count();

                var userbyid = db.USERLOGINs.Where(m => m.userid == id && m.isDeleted == false).FirstOrDefault();
                userbyid.holy_name = holy_name;
                userbyid.first_name = first_name;
                userbyid.last_name = last_name;
                userbyid.email = email;
                userbyid.phone_number = phone_number;
                userbyid.gender = gender;
                userbyid.useradress = useradress;
                userbyid.birthday = birthday;
                userbyid.baptised_date = baptised_date;
                db.Entry(userbyid).State = EntityState.Modified;

                var user_parish_role = db.USER_PARISH_ROLE.Where(m => m.userid == id && m.roleid == 2).FirstOrDefault();
                if (user_parish_role != null)
                {
                    user_parish_role.parishid = parish_id;
                    db.Entry(user_parish_role).State = EntityState.Modified;
                }
                else
                {
                    db.USER_PARISH_ROLE.Add(new USER_PARISH_ROLE
                    {
                        USER_PARISH_ROLE_ID = count_user_parish + 1,
                        roleid = 2,
                        userid = userbyid.userid,
                        parishid = parish_id
                     ,
                        isDeleted = false
                    });
                }
                db.SaveChanges();
                db.Dispose();
            }
        }

        public static void deleted_teacher(int id)
        {
            using (var db = new ChurchModel())
            {
                var userbyid = db.USERLOGINs.Where(m => m.userid == id && m.isDeleted == false).FirstOrDefault();
                userbyid.isDeleted = true;
                db.Entry(userbyid).State = EntityState.Modified;
                db.SaveChanges();
                db.Dispose();
            }
        }
    }
}