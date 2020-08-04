using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.Web;
using System.Web.Mvc;
using MSMS.Models;

namespace MSMS.Areas.OwnerProfile.Controllers
{
    public class ProfileController : Controller
    {
        [HttpGet]
        // GET: OwnerProfile/Profile
        public ActionResult Dashboard()
        {
            return View();
        }

        public ActionResult Profile()
        {
            return View();
        }

        public ActionResult ChangePassword()
        {
            return View();
        }

        public ActionResult ImageRetrieval(string id)
        {
            using (MSMSDBEntities db=new MSMSDBEntities())
            {
                var image=db.Owner_Registration.Find(id);
                return File(image.Photo,"image/jpg");
            }
        }  
    }
}