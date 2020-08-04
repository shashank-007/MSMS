﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MSMS.Models
{
    public class AdminViewModel
    {
        public string Admin_Type { get; set; }
        public string Admin_ID { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public string Phone { get; set; }
        public string Pan_Number { get; set; }
        public string Aadhar_Number { get; set; }
        public string Permanent_Address { get; set; }
        public string Current_Address { get; set; }
        public HttpPostedFileWrapper ImageFile { get; set; }
        public string Status { get; set; }
        public string Password { get; set; }
        public string Reference { get; set; }
    }
}