using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using TNTT_Management.Models;

namespace TNTT_Management.Actions
{
    public class GroupActions
    {
        public static List<LEARNING_GROUP> listGroups()
        {
            using (var db = new ChurchModel())
            {
                return db.LEARNING_GROUP.Where(m => m.IsDeleted == false).ToList();
            }
        }
        public static void addGroup(string group_name, string note, int? parishid)
        {
            using (var db = new ChurchModel())
            {
                int countgroupitem = db.LEARNING_GROUP.ToList().Count();
                var item_exist = db.LEARNING_GROUP.Where(m => m.group_name == group_name
                && parishid == parishid.Value).FirstOrDefault();
                if (item_exist == null)
                {
                    db.LEARNING_GROUP.Add(new LEARNING_GROUP
                    {
                        group_id = countgroupitem + 1,
                        group_name = group_name,
                        note = note,
                        parishid = parishid,
                        IsDeleted = false
                    });

                }
                db.SaveChanges();
                db.Dispose();
            }

        }

        public static LEARNING_GROUP findGroupByID(int id)
        {
            using (var db = new ChurchModel())
            {
                return db.LEARNING_GROUP.Where(m => m.group_id == id).FirstOrDefault();
            }
        }

        public static void editGroup(int id, string group_name, string note
            , int? parish_id)
        {
            using (var db = new ChurchModel())
            {
                var edit_group = db.LEARNING_GROUP.Where(m => m.group_id == id).FirstOrDefault();
                edit_group.group_name = group_name;
                edit_group.note = note;
                edit_group.parishid = parish_id;
                db.Entry(edit_group).State = EntityState.Modified;
                db.SaveChanges();
                db.Dispose();
            }
        }

        public static void deleteGroup(int id)
        {
            using (var db = new ChurchModel())
            {
                var delete_group = db.LEARNING_GROUP.Where(m => m.group_id == id).FirstOrDefault();
                delete_group.IsDeleted = true;
                db.Entry(delete_group).State = EntityState.Modified;
                db.SaveChanges();
                db.Dispose();
            }
        }
    }
}