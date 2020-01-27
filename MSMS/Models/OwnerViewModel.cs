using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MSMS.Models
{
    public class OwnerViewModel
    {
        public string Owner_Email { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public string Phone { get; set; }
        public HttpPostedFileWrapper ImagePAN { get; set; }
        public HttpPostedFileWrapper ImageAadhar { get; set; }
        public string Permanent_Address { get; set; }
        public string Current_Address { get; set; }
        public string Status { get; set; }
        public HttpPostedFileWrapper OwnerImageFile { get; set; }

       
    }
}