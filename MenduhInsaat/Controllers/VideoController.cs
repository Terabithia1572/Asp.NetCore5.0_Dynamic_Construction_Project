using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MenduhInsaat.Controllers
{
    public class VideoController : Controller
    {
        VideoManager videoManager = new VideoManager(new EfVideoRepository());
        AdminManager adminManager = new AdminManager(new EfAdminRepository());
        Context context = new Context();
        public IActionResult Index()
        {
            var username = User.Identity.Name;
            ViewBag.v1 = username;
            var usermail = context.Admins.Where(x => x.Username == username).Select(y => y.Name).FirstOrDefault();
            var userDescription = context.Admins.Where(x => x.Username == username).Select(y => y.ShortDescription).FirstOrDefault();
            var adminID = context.Admins.Where(x => x.Name == usermail).Select(y => y.AdminID).FirstOrDefault();
            ViewBag.v2 = usermail;
            ViewBag.v3 = userDescription.Substring(0, 23);
            var values=videoManager.GetList();

            return View(values);
        }
        [HttpGet]
        public IActionResult UpdateVideo(int id)
        {
            var values = videoManager.TGetByID(id);
            return View(values);
        }
        [HttpPost]
        public IActionResult UpdateVideo(Video video)
        {
            video.VideoStatus = true;
            videoManager.TUpdate(video);
            
            return RedirectToAction("Index","Video");
        }
    }
}
