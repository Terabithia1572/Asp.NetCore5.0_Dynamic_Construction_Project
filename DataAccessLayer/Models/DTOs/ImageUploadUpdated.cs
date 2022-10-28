using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models.DTOs
{
    public class ImageUploadUpdated
    {
        public IFormFile ImageUpload { get; set; }
        public bool ImageStatus { get; set; }
    }
}
