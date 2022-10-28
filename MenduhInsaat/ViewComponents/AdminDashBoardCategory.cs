using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MenduhInsaat.ViewComponents
{
    public class AdminDashBoardCategory:ViewComponent
    {
        CategoryManager categoryManager = new CategoryManager(new EfCategoryRepository());
        public IViewComponentResult Invoke()
        {
            Random r = new Random();
            int sayi = r.Next(25, 100);
            ViewBag.Random = sayi.ToString();
            var values = categoryManager.GetList();
            return View(values);
        }
    }
}
