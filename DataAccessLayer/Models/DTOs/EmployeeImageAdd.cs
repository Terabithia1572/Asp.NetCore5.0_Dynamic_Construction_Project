using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models.DTOs
{
    public class EmployeeImageAdd
    {
        public string EmployeeName { get; set; }
        public string EmployeeSurName { get; set; }
        public IFormFile EmployeeImage { get; set; }
        public string EmployeeTwitter { get; set; }
        public string EmployeeFacebook { get; set; }
        public string EmployeeInstagram { get; set; }
        public string EmployeeLinkedin { get; set; }
        public bool EmployeeStatus { get; set; }
        
    }
}
