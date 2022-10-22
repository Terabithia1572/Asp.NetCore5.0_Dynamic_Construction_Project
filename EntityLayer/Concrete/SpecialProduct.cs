using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class SpecialProduct
    {
        [Key]
        public int SpecialProductID { get; set; }
        public string SpecialProductTitle { get; set; }
        public string SpecialProductContent { get; set; }
        public string SpecialProductImage { get; set; }
        public string SpecialProductTabIndex { get; set; }

    }
}
