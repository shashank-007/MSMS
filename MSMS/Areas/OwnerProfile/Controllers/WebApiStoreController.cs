using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MSMS.BussinessAccess;

namespace MSMS.Areas.OwnerProfile.Controllers
{
    public class WebApiStoreController : ApiController
    {
        BAL objBal = new BAL();

        [HttpGet]
        [Route("api/OwnerProfile/WebApiStore/GetStoreByOwner")]
        public HttpResponseMessage GetStoreByOwner(string OwnerId)
        {
            try
            {
                var store = objBal.GetStoreByOwner(OwnerId);
                if (store == null)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Store Not Found");
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

        public HttpResponseMessage GetStoreByID(string id)
        {
            try
            {
                var store = objBal.GetStoreByID(id);
                if (store == null)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Store Not Found");
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
        [Route("api/OwnerProfile/WebApiStore/Dashboard")]
        public HttpResponseMessage Dashboard(String txtEmail)
        {
            var mail = objBal.Dashboard(txtEmail);
            try
            {
                if (mail == null)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Store Not Found");
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.OK);
                }

            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }
        [HttpPost]
        [Route("api/OwnerProfile/WebApiStore/ChangePassword")]
        public HttpResponseMessage OwnerChangePassword(string OwnerID, string pwd)
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK,objBal.OwnerChangePassword(OwnerID, pwd));
            }
            catch(Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest,ex.Message);
            }
        }

    }
}
