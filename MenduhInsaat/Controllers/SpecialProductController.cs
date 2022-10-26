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
    public class SpecialProductController : Controller
    {


        SpecialProductManager specialProductManager = new SpecialProductManager(new EfSpecialProductRepository());
        public IActionResult Index()
        {
            var values = specialProductManager.GetList();
            return View(values);
        }
    }
}
