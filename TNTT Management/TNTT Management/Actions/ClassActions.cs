using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TNTT_Management.Models;
using System.Data.Entity;
namespace TNTT_Management.Actions
{
    public class ClassActions
    {
        public static List<CLASS> listClasses()
        {
            using (var db = new ChurchModel())
            {
                return db.CLASSes.Include(m => m.LEARNING_GROUP).Where(m => m.IsDeleted == false).ToList();
            }
        }
        public static void addClass(string class_name, string note, int? from_teacher_id, int? group_id)
        {
            using (var db = new ChurchModel())
            {
                int countclassitem = db.CLASSes.ToList().Count();
                db.CLASSes.Add(new CLASS
                {
                    class_id = countclassitem + 1,
                    class_name = class_name,
                    note = note,
                    form_teacher_id = from_teacher_id,
                    group_id = group_id,
                    IsDeleted = false,
                    IsActive = true
                });
                if (from_teacher_id != null)
                {
                    var teacherbyid = db.USERLOGINs.Where(m => m.userid == from_teacher_id).FirstOrDefault();
                    teacherbyid.class_id = countclassitem + 1;
                    db.Entry(teacherbyid).State = EntityState.Modified;
                }
                db.SaveChanges();
                db.Dispose();
            }

        }

        public static void editClass(int id, string class_name, string note
         , int? from_teacher_id, int? group_id)
        {
            using (var db = new ChurchModel())
            {
                var edit_class = db.CLASSes.Where(m => m.class_id == id).FirstOrDefault();
                edit_class.class_name = class_name;
                edit_class.note = note;
                edit_class.form_teacher_id = from_teacher_id;
                edit_class.group_id = group_id;
                db.Entry(edit_class).State = EntityState.Modified;

                var teacherbyid = db.USERLOGINs.Where(m => m.userid == from_teacher_id).FirstOrDefault();

                var amountofteach = db.USERLOGINs.Where(m => m.userid == from_teacher_id && m.class_id == id).ToList().Count;
                if (amountofteach == 0)
                {
                    teacherbyid.class_id = id;
                    db.Entry(teacherbyid).State = EntityState.Modified;
                }

                db.SaveChanges();
                db.Dispose();
            }
        }

        public static CLASS findClassByID(int id)
        {
            using (var db = new ChurchModel())
            {
                return db.CLASSes.Where(m => m.class_id == id).FirstOrDefault();
            }
        }

        public static List<CLASS> findListClassByID(int id)
        {
            using (var db = new ChurchModel())
            {
                return db.CLASSes.Include(m => m.USERLOGIN).Where(m => m.class_id == id).ToList();
            }
        }
        public static List<CLASS> findListClassByTeacherID(int id)
        {
            using (var db = new ChurchModel())
            {
                return db.CLASSes.Include(m => m.USERLOGIN).Where(m => m.form_teacher_id == id).ToList();
            }
        }


        public static void deleteClass(int id)
        {
            using (var db = new ChurchModel())
            {
                var delete_class = db.CLASSes.Where(m => m.class_id == id).FirstOrDefault();
                delete_class.IsDeleted = true;
                db.Entry(delete_class).State = EntityState.Modified;
                db.SaveChanges();
                db.Dispose();
            }
        }

    }
}