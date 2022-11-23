using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MenduhInsaat.ViewComponents
{
    public class VideosPage:ViewComponent
    {
        VideoManager videoManager = new VideoManager(new EfVideoRepository());
        public IViewComponentResult Invoke()
        {
            var values = videoManager.GetList();
            return View(values);
        }
    }
}
