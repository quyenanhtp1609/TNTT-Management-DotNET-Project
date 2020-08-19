using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading;
using System.Web;
using TNTT_Management.Models;

namespace TNTT_Management.Actions
{
    public class StudentActions
    {
        public static List<USERLOGIN> listStudents()
        {
            using (var db = new ChurchModel())
            {
                return db.USERLOGINs.Where(m => m.isDeleted == false).ToList();
            }
        }
        //public static List<USERLOGIN> listStudents()
        //{
        //    using (var db = new ChurchModel())
        //    {
        //        var ketqua = (from u in db.USER_PARISH_ROLE
        //                      where u.USERLOGIN.isDeleted == false && u.roleid == 1
        //                      select u.USERLOGIN).ToList(); ;
        //        return ketqua;
        //    }
        //}
        public static void addStudent(string holy_name,string first_name,string last_name,string email
            ,string phone_number,string gender,string useradress,DateTime? birthday,DateTime? baptised_date,int? parish_id,
            string father_name,string father_phone_number,string mother_name,string mother_phone_number)
        {
            using (var db = new ChurchModel())
            {
        
                int count_user = db.USERLOGINs.Count();
                int count_user_parish = db.USER_PARISH_ROLE.Count();

                USERLOGIN new_user = new USERLOGIN
                {   userid = count_user + 1,
                    holy_name = holy_name,
                    first_name = first_name,
                    last_name = last_name,
                    email = email,
                    phone_number = phone_number,
                    gender = gender,
                    useradress = useradress,
                    birthday = birthday,
                    baptised_date = baptised_date,
                    father_name = father_name,
                    father_phone_number = father_phone_number,
                    mother_name = mother_name,
                    mother_phone_number = mother_phone_number,
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
                        roleid = 1,
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


        public static USERLOGIN findStudentByID(int id)
        {
            using (var db = new ChurchModel())
            {
                return db.USERLOGINs.Where(m => m.userid == id &&  m.isDeleted == false).FirstOrDefault();
            }
        }

        public static void editStudentinfo(int id,string holy_name,string first_name,string last_name,
            string email,string phone_number,string gender,string useradress,DateTime? birthday,
            DateTime? baptised_date,int? parish_id)
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
                userbyid.baptised_date =baptised_date;
                db.Entry(userbyid).State = EntityState.Modified;

                var user_parish_role = db.USER_PARISH_ROLE.Where(m => m.userid == id && m.roleid == 1).FirstOrDefault();
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
                        roleid = 1,
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

        public static void editStudentSacramental(int id,string baptised_place, DateTime? baptised_date
            ,string first_communion_place, DateTime? first_communion_date,string confirmation_place, DateTime? confirmation_date)
        {
            using (var db = new ChurchModel())
            {

                var userbyid = db.USERLOGINs.Where(m => m.userid == id && m.isDeleted == false).FirstOrDefault();
                userbyid.baptised_place = baptised_place;
                userbyid.baptised_date = baptised_date;
                userbyid.first_communion_place = first_communion_place;
                userbyid.first_communion_date = first_communion_date;
                userbyid.comfirmation_place = confirmation_place;
                userbyid.comfirmation_date = confirmation_date;
                db.Entry(userbyid).State = EntityState.Modified;
                db.SaveChanges();
                db.Dispose();
            }
        }

        public static void editStudent_parentInfo(int id,string father_name,string father_phone_number,string mother_name,
            string mother_phone_number)
        {
            using (var db = new ChurchModel())
            {
                var userbyid = db.USERLOGINs.Where(m => m.userid == id && m.isDeleted == false).FirstOrDefault();
                userbyid.father_name = father_name;
                userbyid.father_phone_number = father_phone_number;
                userbyid.mother_name = mother_name;
                userbyid.mother_phone_number = mother_phone_number;
                db.Entry(userbyid).State = EntityState.Modified;
                db.SaveChanges();
                db.Dispose();
            }
        }
        public static void deleted_student(int id)
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