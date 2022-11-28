using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MenduhInsaat.Controllers
{
    
    public class DashBoardController : Controller
    {
        ProductManager productManager = new ProductManager(new EfProductRepository());
        ImageManager imageManager = new ImageManager(new EfImageRepository());
        CommentManager commentManager = new CommentManager(new EfCommentRepository());
        AdminManager adminManager = new AdminManager(new EfAdminRepository());
        Context context = new Context();
        public IActionResult Index()
        {
            return View();
        }
        
        public IActionResult Test()
        {
           
            var toplamurunSayisi = productManager.GetList().Count();
            ViewBag.ToplamUrunSayisi = toplamurunSayisi;
            var toplamresimSayisi = imageManager.GetList().Count();
            ViewBag.ToplamResimSayisi = toplamresimSayisi;
            var toplamYorumSayisi = commentManager.GetList().Count();
            ViewBag.ToplamYorumSayisi = toplamYorumSayisi;

            var username = User.Identity.Name;
            ViewBag.v1 = username;
            var usermail = context.Admins.Where(x => x.Username == username).Select(y => y.Name).FirstOrDefault();
            var userDescription = context.Admins.Where(x => x.Username == username).Select(y => y.ShortDescription).FirstOrDefault();
            var adminID = context.Admins.Where(x => x.Name == usermail).Select(y => y.AdminID).FirstOrDefault();
            ViewBag.v2 = usermail;
            ViewBag.v3 = userDescription.Substring(0,23);
            var values = adminManager.GetAdminByID(adminID);

            return View(values);
        }
        public PartialViewResult AdminNavbarPartial()
        {
            return PartialView();
        }
   
    }
}
