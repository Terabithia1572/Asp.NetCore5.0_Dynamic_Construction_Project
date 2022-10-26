using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using DataAccessLayer.Models.DTOs;
using EntityLayer.Concrete;
using MenduhInsaat.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace MenduhInsaat.Controllers
{
    [AllowAnonymous]
    public class CommentController : Controller
    {
        CommentManager commentManager = new CommentManager(new EfCommentRepository());

        [HttpGet]
        public PartialViewResult AddComment()
        {
            return PartialView();
        }
        [HttpPost]
        public IActionResult AddComment(FileUploadModel fileUploadModel)
        {
            Comment comment = new Comment();
            if (fileUploadModel.ImageUrl !=null)
            {
                var extension = Path.GetExtension(fileUploadModel.ImageUrl.FileName);
                var newimageName = Guid.NewGuid()+extension;
                var location = Path.Combine(Directory.GetCurrentDirectory(),"wwwroot/ImageFolder/",newimageName);
                var stream = new FileStream(location, FileMode.Create);
                fileUploadModel.ImageUrl.CopyTo(stream);
                comment.ImageUrl = "/ImageFolder/" + newimageName;
            }
            comment.CommentUserName = fileUploadModel.CommentUserName;
            comment.CommentTitle = fileUploadModel.CommentTitle;
            comment.CommentContent = fileUploadModel.CommentContent;
            comment.CommentDate = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            comment.CommentStatus = true;
            commentManager.TAdd(comment);
            return RedirectToAction("Index","Product");
        }
    }
}
