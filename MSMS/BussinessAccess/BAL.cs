using MSMS.IRepository;
using MSMS.Models;
using MSMS.Repository;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace MSMS.BussinessAccess
{
    public class BAL
    {
        IReposite IObjRep = new Reposite();

        /// <summary>
        /// 1)
        /// 1.1)this Method is used to check whether the adimin is available or not
        /// </summary>
        /// <param name="UserName"></param>
        /// <param name="Password"></param>
        /// <returns></returns>
        public Admin CheckAdmLogin(string UserName, string Password)
        {
            return IObjRep.CheckAdmLogin(UserName, Password);
        }

        public void AddAdmin(Admin admin)
        {
            IObjRep.AddAdmin(admin);
        }

        public bool ChangePassword(string AdminID, string Pwd)
        {
            int i = 0;
            bool flag = false;
            i = IObjRep.ChangePassword(AdminID, Pwd);
            if (i > 0)
            {
                flag = true;
            }
            return flag;
        }

        public void DeleteAdmin(string id)
        {
            IObjRep.DeleteAdmin(id);
        }

        public void EditAdmin(Admin admin)
        {
            IObjRep.EditAdmin(admin);
        }
        public bool AddAdmin(AdminViewModel model)
        {
            var file = model.ImageFile;
            byte[] ImageBytes = null;
            bool flag = false;
            if (file != null)
            {
                //var fileName = Path.GetFileName(file.FileName);
                //var fileExtension = Path.GetExtension(file.FileName);
                //var fileNameWithoutExtension = Path.GetFileNameWithoutExtension(file.FileName);

                file.SaveAs(HttpContext.Current.Server.MapPath("/img/" + file.FileName));

                BinaryReader reader = new BinaryReader(file.InputStream);
                ImageBytes = reader.ReadBytes(file.ContentLength);

                Admin adm = new Admin();
                adm.Admin_Type = model.Admin_Type;
                adm.Admin_ID = model.Admin_ID;
                adm.Name = model.Name;
                adm.Age = model.Age;
                adm.Gender = model.Gender;
                adm.Password = model.Password;
                adm.Phone = model.Phone;
                adm.Pan_Number = model.Pan_Number;
                adm.Aadhar_Number = model.Aadhar_Number;
                adm.Permanent_Address = model.Permanent_Address;
                adm.Current_Address = model.Current_Address;
                adm.Photo = ImageBytes;
                adm.Status = model.Status;
                adm.Reference = model.Reference;
                flag = IObjRep.AddAdmin(adm);
            }
            return flag;
        }

        public Admin GetAdminByID(string id)
        {

            return IObjRep.GetAdminByID(id);
        }

        public List<Admin> GetAdminsList()
        {
            return IObjRep.GetAdminsList();
        }

        public void AddOwner(Owner_Registration adm)
        {
            IObjRep.AddOwner(adm);
        }
        public Owner_Registration GetOwnerByID(string id)
        {
            return IObjRep.GetOwnerByID(id);
        }

    }
}