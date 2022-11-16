using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
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
        public IActionResult Index()
        {
            var values=videoManager.GetList();

            return View(values);
        }
    }
}
