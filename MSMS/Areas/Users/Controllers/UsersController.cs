﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MSMS.Areas.Users.Controllers
{
    public class UsersController : Controller
    {
        // GET: Users/Users
        public ActionResult Dashboard()
        {
            return View();
        }
        public ActionResult Customer()
        {
            return View();
        }
        public ActionResult Vendor()
        {
            return View();
        }
        public ActionResult Company()
        {
            return View();
        }
    }
}