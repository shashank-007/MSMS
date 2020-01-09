using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MSMS.Areas.AdminLogin.Controllers
{
    public class OperationsAdminController : Controller
    {
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
        public ActionResult StoreDetails()
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
    }
}