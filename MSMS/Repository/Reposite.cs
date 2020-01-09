using MSMS.IRepository;
using MSMS.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;


namespace MSMS.Repository
{
    public class Reposite : IReposite
    {
        //public void AddAdmin(Admin admin)
        //{
        //    using (MSMSDBEntities db=new MSMSDBEntities())
        //    {
        //        db.Admins.Add(admin);
        //        db.SaveChanges();
        //    }
        //}

        public int ChangePassword(string AdminID, string Pwd)
        {
            int i = 0;
            using (MSMSDBEntities db = new MSMSDBEntities())
            {
                var admin = db.Admins.Find(AdminID);
                admin.Password = Pwd;
                db.Admins.Attach(admin);
                db.Entry(admin).Property(a => a.Password).IsModified = true;
                i += db.SaveChanges();
            }
            return i;
        }

        public bool AddAdmin(Admin adm)
        {
            bool flag = false; int i = 0;
            using (MSMSDBEntities db = new MSMSDBEntities())
            {
                db.Admins.Add(adm);
                i += db.SaveChanges();
                if (i > 0)
                { flag = true; }
            }
            return flag;
        }

            /// <summary>
            /// 1)
            /// 1.1)this Method is used to check whether the adimin is available or not
            /// </summary>
            /// <param name="UserName"></param>
            /// <param name="Password"></param>
            /// <returns></returns>
        public Admin CheckAdmLogin(string UserName, string Password)
        {
            
            Admin Adm;
            using (MSMSDBEntities db=new MSMSDBEntities())
            {
                Adm = db.Admins.Where(m=>m.Admin_ID==UserName && m.Password==Password).FirstOrDefault();
                if (Adm != null)
                {
                    return Adm;
                }
            }
            return null;
        }

        public void DeleteAdmin(string id)
        {
            using (MSMSDBEntities db = new MSMSDBEntities())
            {
                var a=db.Admins.Find(id);
                db.Admins.Remove(a);
                db.SaveChanges();
            }
        }

        public void EditAdmin(Admin admin)
        {
            using (MSMSDBEntities db = new MSMSDBEntities())
            {
                db.Entry(admin).State = EntityState.Modified;
                db.SaveChanges();
            }
        }

        public Admin GetAdminByID(string id)
        {
            using (MSMSDBEntities db = new MSMSDBEntities())
            {
                Admin admin = db.Admins.Find(id);   
                return admin;
            }
        }

        public List<Admin> GetAdminsList()
        {
            using (MSMSDBEntities db = new MSMSDBEntities())
            {
                var AdminList = db.Admins.ToList();
               
                return AdminList;
            }
        }

        //2)OperationalAdmin Controller
        //2.1)This method is used to add new OA to database 
        public void AddOwner(Owner_Registration adm)
        {
            using (MSMSDBEntities db = new MSMSDBEntities())
            {
                db.Owner_Registration.Add(adm);
                db.SaveChanges();
            }   
        }
        //2.2)This method is used to add new OA to database
        public Owner_Registration GetOwnerByID(string id)
        {
            using (MSMSDBEntities db = new MSMSDBEntities())
            {
                Owner_Registration admin = db.Owner_Registration.Find(id);
                return admin;
            }
        }
    }
}