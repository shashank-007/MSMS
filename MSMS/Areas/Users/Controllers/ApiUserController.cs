using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MSMS.Models;
using MSMS.BussinessAccess;

namespace MSMS.Areas.Users.Controllers
{
    public class ApiUserController : ApiController
    {
        BAL objBal = new BAL();

        [HttpGet]
        [Route("api/Users/ApiUser/GetCustomersList")]
        public HttpResponseMessage GetCustomersList()
        {  
            try
            {
                var customer = objBal.GetCustomersList();
                if (customer == null)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Store Not Found");
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.OK, customer);
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }
        [HttpGet]
        [Route("api/Users/ApiUser/GetVendorsList")]
        public HttpResponseMessage GetVendorsList()
        {
            try
            {
                var Vendor = objBal.GetVendorsList();
                if (Vendor == null)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Store Not Found");
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.OK, Vendor);
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        [HttpGet]
        [Route("api/Users/ApiUser/GetCompanyList")]
        public HttpResponseMessage GetCompanyList()
        {
            try
            {
                var Company = objBal.GetCompanyList();
                if (Company == null)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Store Not Found");
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.OK, Company);
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        [HttpPost]
        [Route("api/Users/ApiUser/AddCustomer")]
        public HttpResponseMessage AddCustomer(Customer_Details customerDetails)
        {
            try
            {
                objBal.AddCustomer(customerDetails);
                return Request.CreateResponse(HttpStatusCode.Created, customerDetails);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        [HttpPost]
        [Route("api/Users/ApiUser/AddVendors")]
        public HttpResponseMessage AddVendors(Vender_Details venderDetails)
        {
            try
            {
                objBal.AddVendors(venderDetails);
                return Request.CreateResponse(HttpStatusCode.Created, venderDetails);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        [HttpPost]
        [Route("api/Users/ApiUser/AddCompany")]
        public HttpResponseMessage AddCompany(Pharma_Company_Details CompanyDetails)
        {
            try
            {
                objBal.AddCompany(CompanyDetails);
                return Request.CreateResponse(HttpStatusCode.Created, CompanyDetails);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }




        //[HttpGet]
        //[Route("api/Users/ApiUser/SearchCustomer")]
        //public HttpResponseMessage SearchCustomer(int CustId, string CStatus, int Percent)
        //{
        //    try
        //    {
        //        if (CustId != 0 && CStatus != "store" && Percent != 0)
        //        {
        //            return Request.CreateResponse(HttpStatusCode.OK,(from x in objBal.GetCustomersList() where x.Customer_ID== CustId && x.Status== CStatus && x.Percentage==Percent));
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
        //    }
        //}
    }
}
