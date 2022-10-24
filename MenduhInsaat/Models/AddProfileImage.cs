using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MenduhInsaat.Models
{
    public class AddProfileImage
    {
        
        public int CommentID { get; set; }
        public string CommentUserName { get; set; }
        public string CommentTitle { get; set; }
        public string CommentContent { get; set; }
        public IFormFile ImageUrl { get; set; }
        public DateTime CommentDate { get; set; }
        public bool CommentStatus { get; set; }
    }
}
