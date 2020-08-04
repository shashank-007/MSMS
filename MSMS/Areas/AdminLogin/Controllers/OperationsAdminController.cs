using MSMS.BussinessAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MSMS.Models;

namespace MSMS.Areas.AdminLogin.Controllers
{
    public class OperationsAdminController : Controller
    {
        BAL objBal = new BAL();
        // GET: AdminLogin/OperationsAdmin
        public ActionResult OADashboard()
        {
            return View();
        }
        public ActionResult OAProfile()
        {
            return View();
        }
        public ActionResult OAChangePassword()
        {
            return View();
        }
        public ActionResult AddOwner()
        {
            return View();
        }
        public ActionResult ManageOwner()
        {
            return View();
        }
        public ActionResult DeleteStore()
        {
            return View();
        }
        public ActionResult AddStore()
        {
            return View();
        }
        public ActionResult EditStore()
        {
            return View();
        }
        public ActionResult EditOwner()
        {
            return View();
        }
        public ActionResult DeleteOwner()
        {
            return View();
        }
        public JsonResult NewOwner(OwnerViewModel model)
        {
            BAL objBal = new BAL();
            string status = objBal.AddOwner(model);
            return Json(status, JsonRequestBehavior.AllowGet);
        }
        public JsonResult NewStore(StoreViewModel model)
        {
            BAL objBal = new BAL();
            bool status = objBal.AddStore(model);
            return Json(status, JsonRequestBehavior.AllowGet);
        }

        public JsonResult NewEditOwner(OwnerViewModel model)
        {
            BAL objBal = new BAL();
            string status = objBal.EditOwner(model);
            return Json(status,JsonRequestBehavior.AllowGet);
        }


    }
}