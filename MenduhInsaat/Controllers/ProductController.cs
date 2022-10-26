using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MenduhInsaat.Controllers
{
    [AllowAnonymous]
    public class ProductController : Controller
    {
        ProductManager productManager = new ProductManager(new EfProductRepository());
        public IActionResult Index()
        {
            var values = productManager.GetList();
            return View(values);
        }
    }
}
