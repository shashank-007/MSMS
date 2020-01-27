using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MSMS.Models
{
    public class StoreViewModel
    {
        
        public string StoreEmail { get; set; }
        public string Store_Name { get; set; }
        public string Phone { get; set; }
        public string License_Number { get; set; }
        public HttpPostedFileWrapper License_Image_Copy { get; set; }
        public string Address { get; set; }
        public string Pan_Number { get; set; }
        public int Percentage { get; set; }
        public string Status { get; set; }
        public string Owner_Email { get; set; }
    }
}