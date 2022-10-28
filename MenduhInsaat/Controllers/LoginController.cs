using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.IO;
using Microsoft.AspNetCore.Authentication;

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
       
        public async Task<IActionResult> Index(Admin admin)
        {
            Context context = new Context();
            var datavalue = context.Admins.FirstOrDefault(x => x.Username == admin.Username &&
              x.Password == admin.Password);
            if(datavalue !=null)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name,admin.Username)
                };

                var useridentity = new ClaimsIdentity(claims, "a");
                ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(useridentity);
                await HttpContext.SignInAsync(claimsPrincipal);

                return RedirectToAction("Test", "DashBoard");
            }
            else
            {
                return View();
            }

            //var datavalues = context.Admins.FirstOrDefault(x => x.Username == admin.Username &&
            //  x.Password == admin.Password);
            //if (datavalues !=null)
            //{
            //    HttpContext.Session.SetString("Username",admin.Username);
            //    return RedirectToAction("Index", "Product");
            //}
            //else
            //{
            //    return View();
            //}

        }
        public async Task<IActionResult> LogOut()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Index", "Login");
        }

    }   
}
