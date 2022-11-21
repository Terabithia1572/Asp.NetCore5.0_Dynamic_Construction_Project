using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using X.PagedList;

namespace MenduhInsaat.ViewComponents
{
    public class Images:ViewComponent
    {
        ImageManager imageManager = new ImageManager(new EfImageRepository());
        public async Task<IViewComponentResult> InvokeAsync(int page=1)
        {
            var images = imageManager.GetList();
            var values =await images.ToPagedListAsync(page, 4);
            return View(values);
        }

        
    }
}
