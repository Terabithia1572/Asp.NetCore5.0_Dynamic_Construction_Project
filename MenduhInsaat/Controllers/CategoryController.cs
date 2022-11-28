
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
    
    public class CategoryController : Controller
    {
        CategoryManager cm = new CategoryManager(new EfCategoryRepository());
        AdminManager adminManager = new AdminManager(new EfAdminRepository());
        Context context = new Context();
        public IActionResult Index()
        {
            var values = cm.GetList();
            return View(values);
        }
        [HttpGet]
        public IActionResult AddCategory()
        {

            return View();
        }
        [HttpPost]
        public IActionResult AddCategory(Category category)
        {

            category.CategoryStatus = true;
            cm.TAdd(category);

            return RedirectToAction("CategoryList", "Category");
        }
        public IActionResult CategoryList()
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
            var values = cm.GetList();
            return View(values);
        }
        public IActionResult DeleteCategory(int id)
        {
            var values = cm.TGetByID(id);
            cm.TDelete(values);
            return RedirectToAction("CategoryList","Category");
        }
        [HttpGet]
        public IActionResult UpdateCategory(int id)
        {
            var values = cm.TGetByID(id);
                return View(values);
        }
        [HttpPost]

        public IActionResult UpdateCategory(Category category)
        {
            category.CategoryStatus = true;
            cm.TUpdate(category);

            return RedirectToAction("CategoryList", "Category");

        }

    }
}
