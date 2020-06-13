using MSMS.IRepository;
using MSMS.Models;
using MSMS.Repository;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
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

        public string AddOwner(OwnerViewModel model)
        {
            var file = model.OwnerImageFile;
            var file1 = model.ImagePAN;
            var file2 = model.ImageAadhar;

            byte[] ImageBytes = null;
            byte[] PanBytes = null;
            byte[] AadharBytes = null;

            string email = null;
            if (file != null)
            {
                //var fileName = Path.GetFileName(file.FileName);
                //var fileExtension = Path.GetExtension(file.FileName);
                //var fileNameWithoutExtension = Path.GetFileNameWithoutExtension(file.FileName);

                file.SaveAs(HttpContext.Current.Server.MapPath("/img/" + file.FileName));
                file1.SaveAs(HttpContext.Current.Server.MapPath("/img/" + file1.FileName));
                file2.SaveAs(HttpContext.Current.Server.MapPath("/img/" + file2.FileName));


                BinaryReader reader = new BinaryReader(file.InputStream);
                ImageBytes = reader.ReadBytes(file.ContentLength);

                BinaryReader reader1 = new BinaryReader(file1.InputStream);
                PanBytes = reader1.ReadBytes(file1.ContentLength);

                BinaryReader reader2 = new BinaryReader(file2.InputStream);
                AadharBytes = reader2.ReadBytes(file2.ContentLength);

                Owner_Registration adm = new Owner_Registration();
                adm.Owner_Email = model.Owner_Email;
                adm.Name = model.Name;
                adm.Age = model.Age;
                adm.Gender = model.Gender;
                adm.Password = model.Password;
                adm.Phone = model.Phone;
                adm.Pan_Number = PanBytes;
                adm.Aadhar_Number = AadharBytes;
                adm.Permanent_Address = model.Permanent_Address;
                adm.Current_Address = model.Current_Address;
                adm.Photo = ImageBytes;
                adm.Status = model.Status;
                if (IObjRep.AddOwner(adm) > 0)
                {
                    email = adm.Owner_Email;
                }

            }
            return email;
        }

        public string EditOwner(OwnerViewModel model)
        {
            var file = model.OwnerImageFile;
            var file1 = model.ImagePAN;
            var file2 = model.ImageAadhar;

            byte[] ImageBytes = null;
            byte[] PanBytes = null;
            byte[] AadharBytes = null;

            string email = null;
            if (file != null)
            {
                //var fileName = Path.GetFileName(file.FileName);
                //var fileExtension = Path.GetExtension(file.FileName);
                //var fileNameWithoutExtension = Path.GetFileNameWithoutExtension(file.FileName);

                file.SaveAs(HttpContext.Current.Server.MapPath("/img/" + file.FileName));
                file1.SaveAs(HttpContext.Current.Server.MapPath("/img/" + file1.FileName));
                file2.SaveAs(HttpContext.Current.Server.MapPath("/img/" + file2.FileName));


                BinaryReader reader = new BinaryReader(file.InputStream);
                ImageBytes = reader.ReadBytes(file.ContentLength);

                BinaryReader reader1 = new BinaryReader(file1.InputStream);
                PanBytes = reader1.ReadBytes(file1.ContentLength);

                BinaryReader reader2 = new BinaryReader(file2.InputStream);
                AadharBytes = reader2.ReadBytes(file2.ContentLength);

                Owner_Registration adm = new Owner_Registration();
                adm.Owner_Email = model.Owner_Email;
                adm.Name = model.Name;
                adm.Age = model.Age;
                adm.Gender = model.Gender;
                adm.Password = model.Password;
                adm.Phone = model.Phone;
                adm.Pan_Number = PanBytes;
                adm.Aadhar_Number = AadharBytes;
                adm.Permanent_Address = model.Permanent_Address;
                adm.Current_Address = model.Current_Address;
                adm.Photo = ImageBytes;
                adm.Status = model.Status;
                if (IObjRep.EditOwner(adm) > 0)
                {
                    email = adm.Owner_Email;
                }

            }
            return email;
        }


        public Owner_Registration GetOwnerByID(string id)
        {
            return IObjRep.GetOwnerByID(id);
        }
        public List<Owner_Registration> GetOwnerList()
        {
            return IObjRep.GetOwnerList();
        }
        public bool AddStore(StoreViewModel model)
        {
            var file = model.License_Image_Copy;
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

                Store_Registration adm = new Store_Registration();
                adm.StoreEmail = model.StoreEmail;
                adm.Store_Name = model.Store_Name;
                adm.Phone = model.Phone;
                adm.License_Number = model.License_Number;
                adm.License_Image_Copy = ImageBytes;
                adm.Address = model.Address;
                adm.Pan_Number = model.Pan_Number;
                adm.Percentage = model.Percentage;
                adm.Status = model.Status;
                adm.Owner_Email = model.Owner_Email;
                adm.Status = model.Status;
                flag = IObjRep.AddStore(adm);

            }
            return flag;
        }

        //2.5)This method is used to find the store of the owner
        public Store_Registration GetStoreByID(string id)
        {
            return IObjRep.GetStoreByID(id);
        }

        //2.6)This method is used to find the list of stores
        public List<Store_Registration> GetStoreList()
        {
            List<Store_Registration> list = IObjRep.GetStoreList();
            return list;
        }

        //2.7)This method is used to check the details of owner
        public Owner_Registration CheckOwnerLogin(string UserName, string Password)
        {
            return IObjRep.CheckOwnerLogin(UserName, Password);
        }
        //2.8)This method is used to find the stores of owner by ownerID
        public List<Store_Registration> GetStoreByOwner(string OwnerId)
        {
            var list = IObjRep.GetStoreByOwner(OwnerId);
            return list;
        }
        //2.9)This method is used to find the stores of owner by ownerID
        public bool OwnerChangePassword(string AdminId, string Pwd)
        {
            int i = 0;
            bool flag = false;
            i = IObjRep.OwnerChangePassword(AdminId, Pwd);
            if (i > 0)
            {
                return true;
            }
            return flag;
        }
        //2.10)This method is used to delete owner from database
        public void DeleteOwner(string id)
        {
            IObjRep.DeleteOwner(id);
        }

        public string Dashboard(String txtBody)
        {
            string txtEmail = "shashankgenius007@gmail.com";
            string mail = "E-Mail Sent Successfully...!";
            //string  = "We Will Verify Your Changes...!!Thank You";
            string txtSubject = "Requesting For Changes in Dashboard";
            AlternateView Body = this.createEmailBody(txtEmail, txtBody);
            SendMailTo(txtEmail, txtSubject, Body);

            //Response.Write("<script>alert('E-Mail Sent Successfully...!');</script>");
            return mail;
        }

        private AlternateView createEmailBody(string userName, string message)
        {
            string path = HttpContext.Current.Server.MapPath("~/img/Samsung1.jpg");
            LinkedResource Img = new LinkedResource(path, MediaTypeNames.Image.Jpeg);
            Img.ContentId = "MyImage";
            //Byte[] bytes = GetImageByte();
            //MemoryStream ms = new MemoryStream(bytes);
            //LinkedResource Img = new LinkedResource(ms, "image/jpeg");
            //Img.ContentId = "MyImage";
            string body = string.Empty;
            using (StreamReader reader = new StreamReader(HttpContext.Current.Server.MapPath("~/Views/MailFormate.html")))
            {
                body = reader.ReadToEnd();
            }
            body = body.Replace("{UserName}", userName);     //replacing the required things             
            body = body.Replace("{message}", message);       //replacing the required things  
            body = body.Replace("{ImgPath}", "cid:MyImage"); //replacing the required things

            AlternateView AV = AlternateView.CreateAlternateViewFromString(body, null, MediaTypeNames.Text.Html);
            AV.LinkedResources.Add(Img);
            return AV;
        }

        //public byte[] GetImageByte()
        //{
        //    Byte[] bytes = null;
        //    string Con = "server=DESKTOP-N1VQO3J\\SQLEXPRESS;database=MyDB;uid=sa;password=123";
        //    SqlConnection Cn = new SqlConnection(Con);
        //    string strQuery = "select ProdImg1 from ProductsOrder where OrderID=@OrderID";
        //    SqlCommand cmd = new SqlCommand(strQuery, Cn);
        //    cmd.Parameters.AddWithValue("@OrderID", 10001);
        //    SqlDataAdapter da = new SqlDataAdapter(cmd);
        //    DataTable dt = new DataTable();
        //    da.Fill(dt);
        //    bytes = (Byte[])dt.Rows[0]["ProdImg1"];
        //    return bytes;
        //}

        public void SendMailTo(string To, string Subject, AlternateView Body)
        {
            SmtpClient smtpc = new SmtpClient("smtp.gmail.com");
            smtpc.Port = 587;
            smtpc.EnableSsl = true;
            smtpc.UseDefaultCredentials = false;
            string userId = "shashank.vtalent@gmail.com"; //<--Enter your gmail id here
            string pass = "shashank@123";  //<--Enter Your gmail password here           
            //string body = Body;  //Message body
            smtpc.Credentials = new NetworkCredential(userId, pass);
            MailMessage message = new MailMessage();
            message.To.Add(To);// Email-ID of Receiver  
            message.Subject = Subject;// Subject of Email  
            message.From = new System.Net.Mail.MailAddress("shashank.vtalent@gmail.com");// Email-ID of Sender  
            message.IsBodyHtml = true;
            message.AlternateViews.Add(Body);
            smtpc.Send(message);
        }
        //3)User Profile
        //3.1)This method is used to get list of Customers
        public List<Customer_Details> GetCustomersList()
        {
           return IObjRep.GetCustomersList();
        }

        //3.2)This method is used to get list of Vendors
        public List<Vender_Details> GetVendorsList()
        {
            return IObjRep.GetVendorsList();
        }

        //3.3)This method is used to get list of Owners
        public List<Pharma_Company_Details> GetCompanyList()
        {
            return IObjRep.GetCompanyList();
        }

        //3.4)This method is used to add Customers
        public void AddCustomer(Customer_Details customerDetails)
        {
            IObjRep.AddCustomer(customerDetails);
        }

        //3.5)This method is used to add Vendors
        public void AddVendors(Vender_Details venderDetails)
        {
            IObjRep.AddVendors(venderDetails);
        }

        //3.6)This method is used to add Company
        public void AddCompany(Pharma_Company_Details CompanyDetails)
        {
            IObjRep.AddCompany(CompanyDetails);
        }
    }
}