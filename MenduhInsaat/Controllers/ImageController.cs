using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MenduhInsaat.Controllers
{
    public class ImageController : Controller
    {
        ImageManager imageManager = new ImageManager(new EfImageRepository());
        Context context = new Context();

        public IActionResult Index()
        {
            var values = imageManager.GetList();
            return View(values);
        }
    }
}
