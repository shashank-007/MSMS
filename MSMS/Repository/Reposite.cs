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
        public int AddOwner(Owner_Registration adm)
        {
            int i = 0;
            using (MSMSDBEntities db = new MSMSDBEntities())
            {
                db.Owner_Registration.Add(adm);
                i += db.SaveChanges();  
            }
            return i;
        }
        //2.2)This method is used to find OA from database
        public Owner_Registration GetOwnerByID(string id)
        {
            using (MSMSDBEntities db = new MSMSDBEntities())
            {
                Owner_Registration admin = db.Owner_Registration.Find(id);
                return admin;
            }
        }
        //2.3)This method is used to get list of Owners
        public List<Owner_Registration> GetOwnerList()
        {
            using (MSMSDBEntities db=new MSMSDBEntities())
            {
                return db.Owner_Registration.ToList();
            }
        }

        //2.4)This method is used to add new OA to database 
        public bool AddStore(Store_Registration adm)
        {
            bool flag = false;
            int i = 0;
            using (MSMSDBEntities db = new MSMSDBEntities())
            {
                db.Store_Registration.Add(adm);
                i += db.SaveChanges();
                if (i > 0)
                { flag = true; }
            }
            return flag;
        }

        //2.5)This method is used to find the store of the owner
        public Store_Registration GetStoreByID(string id)
        {
            using (MSMSDBEntities db=new MSMSDBEntities())
            {
                return db.Store_Registration.Find(id);
            }
        }

        //2.6)This method is used to find the list of stores
        public List<Store_Registration> GetStoreList()
        {
            using (MSMSDBEntities db=new MSMSDBEntities())
            {
                List<Store_Registration> list = db.Store_Registration.ToList();
                return list;
            }
        }

        //2.7)This method is used to check the details of owner
        public Owner_Registration CheckOwnerLogin(string UserName, string Password)
        {
            Owner_Registration adm;
            using (MSMSDBEntities db=new MSMSDBEntities())
            {
                adm = db.Owner_Registration.Where(m => m.Owner_Email== UserName && m.Password== Password).FirstOrDefault();
                if (adm!=null)
                {
                    return adm;
                }
            }
            return null;
        }
        //2.8)This method is used to find the stores of owner by ownerID
        public List<Store_Registration> GetStoreByOwner(string OwnerId)
        {
            using (MSMSDBEntities db=new MSMSDBEntities())
            {
                List<Store_Registration> adm = db.Store_Registration.Where(m=>m.Owner_Email== OwnerId).ToList();
                return adm;
            }
        }
        //2.9)This method is used to change Owner password in database
        public int OwnerChangePassword(string ownerID, string pwd)
        {
            int i = 0;
            using (MSMSDBEntities db=new MSMSDBEntities())
            {
                var owner = db.Owner_Registration.Find(ownerID);
                owner.Password = pwd;
                db.Owner_Registration.Attach(owner);
                db.Entry(owner).Property(a => a.Password).IsModified = true;
                i += db.SaveChanges();
            }
            return i;
        }

        //2.10)This method is used to delete owner from database
        public void DeleteOwner(string id)
        {
            using (MSMSDBEntities db=new MSMSDBEntities())
            {
                var a = db.Owner_Registration.Find(id);
                db.Owner_Registration.Remove(a);
                db.SaveChanges();
            }
        }

        //2.11)This method is used to edit owner in database
        public int EditOwner(Owner_Registration adm)
        {
            int i = 0;
            using (MSMSDBEntities db = new MSMSDBEntities())
            {
                db.Entry(adm).State = EntityState.Modified;
                i += db.SaveChanges();
            }
            return i;
        }

        //3)User Profile
        //3.1)This method is used to get list of Customers
        public List<Customer_Details> GetCustomersList()
        {
            using (MSMSDBEntities db=new MSMSDBEntities())
            {
                List<Customer_Details> list = db.Customer_Details.ToList();
                return list;
            }
        }

        //3.2)This method is used to get list of Vendors
        public List<Vender_Details> GetVendorsList()
        {
            using (MSMSDBEntities db = new MSMSDBEntities())
            {
                List<Vender_Details> list = db.Vender_Details.ToList();
                return list;
            }
        }

        //3.3)This method is used to get list of Owners
        public List<Pharma_Company_Details> GetCompanyList()
        {
            using (MSMSDBEntities db = new MSMSDBEntities())
            {
                List<Pharma_Company_Details> list = db.Pharma_Company_Details.ToList();
                return list;
            }
        }

        //3.4)This method is used to add Customers
        public bool AddCustomer(Customer_Details customerDetails)
        {
            bool flag = false;
            int i = 0;
            using (MSMSDBEntities db=new MSMSDBEntities())
            {
                db.Customer_Details.Add(customerDetails);
                i += db.SaveChanges();
                if (i>0)
                {
                    return true;
                }
            }
            return flag;
        }

        //3.5)This method is used to add Vendors
        public bool AddVendors(Vender_Details venderDetails)
        {
            bool flag = false;
            int i = 0;
            using (MSMSDBEntities db = new MSMSDBEntities())
            {
                db.Vender_Details.Add(venderDetails);
                i += db.SaveChanges();
                if (i > 0)
                {
                    return true;
                }
            }
            return flag;
        }

        //3.6)This method is used to add Company
        public bool AddCompany(Pharma_Company_Details CompanyDetails)
        {
            bool flag = false;
            int i = 0;
            using (MSMSDBEntities db = new MSMSDBEntities())
            {
                db.Pharma_Company_Details.Add(CompanyDetails);
                i += db.SaveChanges();
                if (i > 0)
                {
                    return true;
                }
            }
            return flag;
        }
    }
}