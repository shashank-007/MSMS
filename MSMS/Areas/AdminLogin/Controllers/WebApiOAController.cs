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

        //[HttpPost]
        //[Route("api/AdminLogin/WebApiOA/AddOwner")]
        //public HttpResponseMessage AddOwner(Owner_Registration admin)
        //{
        //    try
        //    {
        //        objBal.AddOwner(admin);
        //        return Request.CreateResponse(HttpStatusCode.Created, admin);
        //    }
        //    catch (Exception ex)
        //    {
        //        return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
        //    }
        //}

        [HttpGet]
        [Route("api/AdminLogin/WebApiOA/GetOwnerList")]
        public HttpResponseMessage GetOwnerList()
        {
            try
            {
                var List = objBal.GetOwnerList();
                if (List == null)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Owner was not available...!!");
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.OK, List);
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        [HttpGet]
        [Route("api/AdminLogin/WebApiOA/GetStoreById/{id}")]
        public HttpResponseMessage GetStoreById(string id)
        {
            try
            {
                var store = objBal.GetStoreByID(id);
                if (store == null)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "store ID : " + id + " data was not there in database...!");
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.OK, store);
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        [HttpGet]
        [Route("api/AdminLogin/WebApiOA/GetStoreList")]
        public HttpResponseMessage GetStoreList()
        {
            try
            {
                var List = objBal.GetStoreList();
                if (List == null)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Store was not available...!!");
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.OK, List);
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        [HttpGet]
        [Route("api/AdminLogin/WebApiOA/CheckOwnerLogin")]
        public HttpResponseMessage CheckOwnerLogin(string UserName, string Password)
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, objBal.CheckOwnerLogin(UserName, Password));
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        [HttpGet]
        [Route("api/AdminLogin/WebApiOA/SearchStore")]
        public HttpResponseMessage SearchStore(string Email,string Status, int Percent)
        {
            try
            {
                if (Email!="store"&&Status!= "store"&& Percent != 0)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, (from x in objBal.GetStoreList() where x.StoreEmail == Email && x.Status == Status && x.Percentage == Percent select x).ToList());
                }
                else if (Email!= "store"&&Status!= "store"&&Percent==0)
                {
                    return Request.CreateResponse(HttpStatusCode.OK,(from x in objBal.GetStoreList() where x.StoreEmail==Email&&x.Status==Status select x).ToList());
                }
                else if (Email != "store" && Status == "store" && Percent != 0)
                {
                    return Request.CreateResponse(HttpStatusCode.OK,(from x in objBal.GetStoreList() where x.StoreEmail==Email&&x.Percentage==Percent select x).ToList());
                }
                else if (Email == "store" && Status != "store" && Percent != 0)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, (from x in objBal.GetStoreList() where x.Status == Status && x.Percentage == Percent select x).ToList());
                }
                else if (Email != "store" && Status == "store" && Percent == 0)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, (from x in objBal.GetStoreList() where x.StoreEmail == Email select x).ToList());
                }
                else if (Email == "store" && Status == "store" && Percent != 0)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, (from x in objBal.GetStoreList() where x.Percentage == Percent select x).ToList());
                }
                else if (Email == "store" && Status != "store" && Percent == 0)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, (from x in objBal.GetStoreList() where x.Status == Status select x).ToList());
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.OK,objBal.GetStoreList());
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest,ex.Message);
            }
        }
    }
}
