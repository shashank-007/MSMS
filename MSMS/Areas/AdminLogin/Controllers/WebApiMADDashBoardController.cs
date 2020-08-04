using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using MSMS.BussinessAccess;
using MSMS.Models;

namespace MSMS.Areas.AdminLogin.Controllers
{
    public class WebApiMADDashBoardController : ApiController
    {
        BAL objBal = new BAL();
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="UserName"></param>
        /// <param name="Password"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("api/AdminLogin/WebApiMADDashboard/CheckAdminLogin")]
        public HttpResponseMessage CheckAdminLogin(string UserName,string Password)
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK,objBal.CheckAdmLogin(UserName,Password));
            }
            catch(Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }
        
        [HttpGet]
        [Route("api/AdminLogin/WebApiMADDashBoard/GetAdminsList")]
        public HttpResponseMessage GetAdminsList()
        {
            try
            {
                var AdminList = objBal.GetAdminsList();
                if (AdminList.Count == 0)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Admin data not found in database...!");
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.OK, AdminList);
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        [HttpGet]
        [Route("api/AdminLogin/WebApiMADDashBoard/GetAdminByID/{id}")]
        public HttpResponseMessage GetAdminByID(string id)
        {
            try
            {
                var admin = objBal.GetAdminByID(id);
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
        [Route("api/AdminLogin/WebApiMADDashBoard/AddAdmin")]
        public HttpResponseMessage AddAdmin(Admin admin)
        {
            try
            {
                objBal.AddAdmin(admin);
                return Request.CreateResponse(HttpStatusCode.Created, admin);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }
        [HttpPost]
        [Route("api/AdminLogin/WebApiMADDashBoard/EditAdmin")]
        public HttpResponseMessage EditAdmin(Admin admin)
        {
            try
            {
                objBal.EditAdmin(admin);
                return Request.CreateResponse(HttpStatusCode.Created,admin);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest,ex.Message);
            }
        }

        [HttpPost]
        [Route("api/AdminLogin/WebApiMADDashBoard/DeleteAdmin/{id}")]
        public HttpResponseMessage DeleteAdmin(string id)
        {
            try
            {
                objBal.DeleteAdmin(id);
                return Request.CreateResponse(HttpStatusCode.OK, id);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        [HttpPost]
        [Route("api/Admin/AdminApi/ChangePassword")]
        public HttpResponseMessage ChangePassword(string AdminId, string Pwd)
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.Created, objBal.ChangePassword(AdminId, Pwd));
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }
    }
}
