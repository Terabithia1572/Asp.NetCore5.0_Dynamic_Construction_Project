using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Organization
    {
        [Key]
        public int OrganizationID { get; set; }
        public string OrganizationTitle { get; set; }
        public string OrganizationDetails1 { get; set; }
        public string OrganizationDetails2 { get; set; }
        public string OrganizationShortDescription1 { get; set; }
        public string OrganizationShortDescription2 { get; set; }
        public string OrganizationShortDescription3 { get; set; }
        public string OrganizationImage { get; set; }
    }
}
