using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using DataAccessLayer.Models.DTOs;
using EntityLayer.Concrete;
using MenduhInsaat.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MenduhInsaat.Controllers
{
    public class ImageController : Controller
    {
        ImageManager imageManager = new ImageManager(new EfImageRepository());
        AdminManager adminManager = new AdminManager(new EfAdminRepository());   
        Context context = new Context();

        public IActionResult Index()
        {
            var username = User.Identity.Name;
            ViewBag.v1 = username;
            var usermail = context.Admins.Where(x => x.Username == username).Select(y => y.Name).FirstOrDefault();
            var userDescription = context.Admins.Where(x => x.Username == username).Select(y => y.ShortDescription).FirstOrDefault();
            var userProfile = context.Admins.Where(x => x.Username == username).Select(y => y.ImageURL).FirstOrDefault();
            ViewBag.v4 = userProfile;
            var adminID = context.Admins.Where(x => x.Name == usermail).Select(y => y.AdminID).FirstOrDefault();
            ViewBag.v2 = usermail;
            ViewBag.v3 = userDescription.Substring(0, 23);
            var values = imageManager.GetList();
            return View(values);
        }

        [HttpGet]
        public IActionResult AddImage()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddImage(ImageUploadModel imageUploadModel)
        {
            Image image = new Image();

            if (imageUploadModel.ImageUpload != null)
            {
                var extension = Path.GetExtension(imageUploadModel.ImageUpload.FileName);
                var newimageName = Guid.NewGuid() + extension;
                var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/WorkImage/", newimageName);
                var stream = new FileStream(location, FileMode.Create);
                imageUploadModel.ImageUpload.CopyTo(stream);
                image.ImageUpload = "/WorkImage/" + newimageName;
            }
            
            image.ImageStatus = true;
            imageManager.TAdd(image);
            return RedirectToAction("Index", "Image");
        }
        public IActionResult DeleteImage(int id)
        {
            var imageValue = imageManager.TGetByID(id);
            imageManager.TDelete(imageValue);
            return RedirectToAction("Index", "Image");
        }

        [HttpGet]
        public IActionResult UpdateImage(int id)
        {
            var username = User.Identity.Name;
            ViewBag.v1 = username;
            var usermail = context.Admins.Where(x => x.Username == username).Select(y => y.Name).FirstOrDefault();
            var userDescription = context.Admins.Where(x => x.Username == username).Select(y => y.ShortDescription).FirstOrDefault();
            var userProfile = context.Admins.Where(x => x.Username == username).Select(y => y.ImageURL).FirstOrDefault();
            ViewBag.v4 = userProfile;
            var adminID = context.Admins.Where(x => x.Name == usermail).Select(y => y.AdminID).FirstOrDefault();
            ViewBag.v2 = usermail;
            ViewBag.v3 = userDescription.Substring(0, 23);
            var values = imageManager.TGetByID(id);
            return View(values);
        }

        [HttpPost]
        public IActionResult UpdateImage(Image image,IFormFile imagefile)
        {
            if (imagefile != null)
            {
                image.ImageUpload = AddImagePage.ImageAdd(imagefile, AddImagePage.StaticProfileImageLocation());
            }
            image.ImageStatus = true;         
            imageManager.TUpdate(image);
            return RedirectToAction("Index", "Image");
        }
    }
}
