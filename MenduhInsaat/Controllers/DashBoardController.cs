using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
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
            ViewBag.ToplamYorumSayisi = toplamresimSayisi;

            return View();
        }
        public PartialViewResult AdminNavbarPartial()
        {
            return PartialView();
        }
    }
}
