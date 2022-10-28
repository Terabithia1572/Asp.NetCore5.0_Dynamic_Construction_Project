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
    
    public class SpecialProductController : Controller
    {


        SpecialProductManager specialProductManager = new SpecialProductManager(new EfSpecialProductRepository());
        [AllowAnonymous]
        public IActionResult Index()
        {
            var values = specialProductManager.GetList();
            return View(values);
        }
       
        public IActionResult SpecialProductList()
        {
            var values = specialProductManager.GetList();
            return View(values);
        }
        [HttpGet]
        public IActionResult AddSpecialProduct()
        {
           
            return View();
        }
        [HttpPost]
        public IActionResult AddSpecialProduct(SpecialProduct specialProduct)
        {
            Random r = new Random();
           int sayi= r.Next(8, 100);
            specialProduct.SpecialProductTabIndex = "tab-"+sayi;
            specialProductManager.TAdd(specialProduct);
            return RedirectToAction("SpecialProductList", "SpecialProduct");
        }

        public IActionResult DeleteSpecialProduct(int id)
        {
            var productvalue = specialProductManager.TGetByID(id);
            specialProductManager.TDelete(productvalue);
            return RedirectToAction("SpecialProductList", "SpecialProduct");
        }
        [HttpGet]
        public IActionResult EditSpecialProduct(int id)
        {
           
            var productvalues = specialProductManager.TGetByID(id);

            return View(productvalues);
        }
        [HttpPost]

        public IActionResult EditSpecialProduct(SpecialProduct specialProduct)
        {


            Random r = new Random();
            int sayi = r.Next(8, 100);
            specialProduct.SpecialProductTabIndex = "tab-" + sayi;
            
            specialProductManager.TUpdate(specialProduct);
            return RedirectToAction("SpecialProductList", "SpecialProduct");
        }
    }
}
