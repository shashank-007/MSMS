using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MSMS.BussinessAccess;
using MSMS.Models;

namespace MSMS.Areas.AdminLogin.Controllers
{
  
    public class AdminLoginController : Controller
    {
        //BAL objBal = new BAL();
        // GET: AdminLogin/AdminLogin

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ActionResult Login()
        {
            return View();
        }
        public ActionResult DashBoard()
        {
            return View();
        }
        public ActionResult MAAdd()
        {
            return View();
        }
        public ActionResult MADetails()
        {
            return View();
        }
        public ActionResult MADelete()
        {
            return View();
        }
        public ActionResult MAEdit()
        {
            return View();
        }

        public ActionResult MAChangePwd()
        {
            return View();
        }
        public JsonResult NewAdmin(AdminViewModel model)
        {
            BAL objBal = new BAL();
            bool status = objBal.AddAdmin(model);
            return Json(status, JsonRequestBehavior.AllowGet);
        }

        public ActionResult MAIndex()
        {
            using (MSMSDBEntities db=new MSMSDBEntities())
            {
                return View(db.Admins.ToList());
            }
            
        }
    }
}