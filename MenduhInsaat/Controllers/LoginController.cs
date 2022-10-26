using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MenduhInsaat.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
       
        public IActionResult Index(Admin admin)
        {
            Context context = new Context();
            var datavalues = context.Admins.FirstOrDefault(x => x.Username == admin.Username &&
              x.Password == admin.Password);
            if (datavalues !=null)
            {
                HttpContext.Session.SetString("Username",admin.Username);
                return RedirectToAction("Index", "Product");
            }
            else
            {
                return View();
            }
           
        }

    }   
}
