using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MSMS.BussinessAccess;
using MSMS.Models;

namespace MSMS.Areas.AdminLogin.Controllers
{
    public class WebApiOAController : ApiController
    {
        BAL objBal = new BAL();

        [HttpGet]
        [Route("api/AdminLogin/WebApiOA/GetOwnerByID/{id}")]
        public HttpResponseMessage GetOwnerByID(string id)
        {
            try
            {
                var admin = objBal.GetOwnerByID(id);
                if (admin == null)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Admin ID : " + id + " data was not there in database...!");
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.OK, admin);
                }

            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        [HttpPost]
        [Route("api/AdminLogin/WebApiOA/AddOwner")]
        public HttpResponseMessage AddOwner(Owner_Registration admin)
        {
            try
            {
                objBal.AddOwner(admin);
                return Request.CreateResponse(HttpStatusCode.Created, admin);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }
    }
}
