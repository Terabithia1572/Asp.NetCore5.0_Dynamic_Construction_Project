using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MenduhInsaat.Controllers
{
    
    public class ProductController : Controller
    {
        ProductManager productManager = new ProductManager(new EfProductRepository());
        CategoryManager categoryManager = new CategoryManager(new EfCategoryRepository());
        [AllowAnonymous]
        public IActionResult Index()
        {
            var values = productManager.GetList();
            return View(values);
        }
        [AllowAnonymous]
        public IActionResult ProductList()
        {
            var values = productManager.GetList();
            return View(values);
        }
        [HttpGet]
        public IActionResult AddProduct()
        {
            List<SelectListItem> categoryValues = (from x in categoryManager.GetList()
                                                   select new SelectListItem
                                                   {
                                                       Text = x.CategoryName,
                                                       Value = x.CategoryID.ToString()
                                                   }).ToList();
            ViewBag.cv = categoryValues;
            return View();
        }
        [HttpPost]
        public IActionResult AddProduct(Product product)
        {
            string[] rastgeleFiltre = new string[3];
            rastgeleFiltre[0] = "filter-starters";
            rastgeleFiltre[1] = "filter-salads";
            rastgeleFiltre[2] = "filter-specialty";
            Random r = new Random();
            int sayi = r.Next(0, 3);
            product.ProductStatus = true;
            product.ProductFilter = rastgeleFiltre[sayi];
            productManager.TAdd(product);
            return RedirectToAction("ProductList", "Product");
        }

        public IActionResult DeleteProduct(int id)
        {
            var blogvalue = productManager.TGetByID(id);
            productManager.TDelete(blogvalue);
            return RedirectToAction("ProductList", "Product");
        }
        [HttpGet]
        public IActionResult EditProduct(int id)
        {
            List<SelectListItem> categoryValues = (from x in categoryManager.GetList()
                                                   select new SelectListItem
                                                   {
                                                       Text = x.CategoryName,
                                                       Value = x.CategoryID.ToString()
                                                   }).ToList();
            ViewBag.cm = categoryValues;
            var blogvalues = productManager.TGetByID(id);

            return View(blogvalues);
        }
        [HttpPost]

        public IActionResult EditProduct(Product product)
        {

            List<SelectListItem> categoryValues = (from x in categoryManager.GetList()
                                                   select new SelectListItem
                                                   {
                                                       Text = x.CategoryName,
                                                       Value = x.CategoryID.ToString()
                                                   }).ToList();
            string[] rastgeleFiltre = new string[3];
            rastgeleFiltre[0] = "filter-starters";
            rastgeleFiltre[1] = "filter-salads";
            rastgeleFiltre[2] = "filter-specialty";
            Random r = new Random();
            int sayi = r.Next(0, 3);
            product.ProductStatus = true;
            product.ProductFilter = rastgeleFiltre[sayi];
            productManager.TUpdate(product);
            return RedirectToAction("ProductList", "Product");
        }
    }
}
