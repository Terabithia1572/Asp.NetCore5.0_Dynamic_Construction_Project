
using BusinessLayer.Concrete;
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
    [AllowAnonymous]
    public class CategoryController : Controller
    {
        CategoryManager cm = new CategoryManager(new EfCategoryRepository());
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
