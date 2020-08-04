using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MSMS.Models;
using MSMS.BussinessAccess;
using CrystalDecisions.CrystalReports.Engine;
using System.IO;

namespace MSMS.Areas.Users.Controllers
{
    public class UsersController : Controller
    {
        BAL objBal = new BAL();
        // GET: Users/Users
        public ActionResult Dashboard()
        {
            return View();
        }
        public ActionResult Customer()
        {
            using (MSMSDBEntities db=new MSMSDBEntities())
            {
                return View(db.Customer_Details.ToList());
            }      
        }
        public ActionResult CustomerPDF()
        {
            using (MSMSDBEntities db=new MSMSDBEntities())
            {
                var List = (from x in db.Customer_Details select new { x.Customer_ID, x.Customer_Name,x.Phone_No,x.Email,x.City,x.Percentage,x.Status }).ToList();
                ReportDocument rd = new ReportDocument();
                rd.Load(Path.Combine(Server.MapPath("~/Reports"), "CustomerCrystalReport.rpt"));
                rd.SetDataSource(List);
                Response.Buffer = false;
                Response.ClearContent();
                Response.ClearHeaders();
                try
                {
                    Stream stream = rd.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
                    stream.Seek(0, SeekOrigin.Begin);
                    return File(stream, "application/pdf", "CustomerData.pdf");
                }
                catch
                {
                    throw;
                }
            }
        }
        
        public ActionResult Vendor()
        {
            using (MSMSDBEntities db = new MSMSDBEntities())
            {
                return View(db.Vender_Details.ToList());
            }
        }
        public ActionResult VendorPDF()
        {
            using (MSMSDBEntities db = new MSMSDBEntities())
            {
                var List = (from x in db.Vender_Details select new { x.Vender_ID, x.Vender_Name, x.Phone_No, x.Email, x.City, x.Address, x.Percentage, x.Status }).ToList();
                ReportDocument rd = new ReportDocument();
                rd.Load(Path.Combine(Server.MapPath("~/Reports"), "VendorCrystalReport.rpt"));
                rd.SetDataSource(List);
                Response.Buffer = false;
                Response.ClearContent();
                Response.ClearHeaders();
                try
                {
                    Stream stream = rd.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
                    stream.Seek(0, SeekOrigin.Begin);
                    return File(stream, "application/pdf", "VendorData.pdf");
                }
                catch
                {
                    throw;
                }
            }
        }
        public ActionResult Company()
        {
            using (MSMSDBEntities db = new MSMSDBEntities())
            {
                return View(db.Pharma_Company_Details.ToList());
            }
        }
        public ActionResult CompanyPDF()
        {
            using (MSMSDBEntities db = new MSMSDBEntities())
            {
                var List = (from x in db.Pharma_Company_Details select new { x.Company_Id, x.Company_Name}).ToList();
                ReportDocument rd = new ReportDocument();
                rd.Load(Path.Combine(Server.MapPath("~/Reports"), "CompanyCrystalReport.rpt"));
                rd.SetDataSource(List);
                Response.Buffer = false;
                Response.ClearContent();
                Response.ClearHeaders();
                try
                {
                    Stream stream = rd.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
                    stream.Seek(0, SeekOrigin.Begin);
                    return File(stream, "application/pdf", "CompanyData.pdf");
                }
                catch
                {
                    throw;
                }
            }
        }
    }
}