using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using DataAccessLayer.Models.DTOs;
using DNTCaptcha.Core;
using EntityLayer.Concrete;
using MenduhInsaat.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace MenduhInsaat.Controllers
{
    
    public class CommentController : Controller
    {
        private readonly IDNTCaptchaValidatorService _validatorService;
        private readonly DNTCaptchaOptions _captchaOptions;

        CommentManager commentManager = new CommentManager(new EfCommentRepository());
        AdminManager adminManager = new AdminManager(new EfAdminRepository());
        Context context = new Context();
        [AllowAnonymous]
        [HttpGet]
        public PartialViewResult AddComment()
        {
            return PartialView();
        }
        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddComment(FileUploadModel fileUploadModel)
        {
            Comment comment = new Comment();
            if (ModelState.IsValid) 
            {
                if(!_validatorService.HasRequestValidCaptchaEntry(Language.Turkish,DisplayMode.ShowDigits))
                {
                    this.ModelState.AddModelError(_captchaOptions.CaptchaComponent.CaptchaInputName, "Lütfen Doğrulama Kodunu Girin.");
                    return RedirectToAction("Index", "Product");
                }
            }
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
        
        public IActionResult CommentList()
        {
            var username = User.Identity.Name;
            ViewBag.v1 = username;
            var usermail = context.Admins.Where(x => x.Username == username).Select(y => y.Name).FirstOrDefault();
            var userDescription = context.Admins.Where(x => x.Username == username).Select(y => y.ShortDescription).FirstOrDefault();
            var adminID = context.Admins.Where(x => x.Name == usermail).Select(y => y.AdminID).FirstOrDefault();
            ViewBag.v2 = usermail;
            ViewBag.v3 = userDescription.Substring(0, 23);
            var values = commentManager.GetList();
            return View(values);
        }
        public IActionResult DeleteComment(int id)
        {
            var commentValue = commentManager.TGetByID(id);
            commentManager.TDelete(commentValue);
            return RedirectToAction("CommentList", "Comment");
        }
        public IActionResult DeleteComment1(int id)
        {
            var commentValue = commentManager.TGetByID(id);
            commentManager.TDelete(commentValue);
            return RedirectToAction("Test", "DashBoard");
        }
        public CommentController(IDNTCaptchaValidatorService validatorService, IOptions<DNTCaptchaOptions> options)
        {
            _validatorService = validatorService;

            _captchaOptions = options == null ? throw new ArgumentNullException(nameof(options)) : options.Value;
        }

    }
}
