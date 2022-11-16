using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Video
    {
        [Key]
        public int VideoID { get; set; }
        public string VideoLink { get; set; }
        public bool VideoStatus { get; set; }
    }
}
