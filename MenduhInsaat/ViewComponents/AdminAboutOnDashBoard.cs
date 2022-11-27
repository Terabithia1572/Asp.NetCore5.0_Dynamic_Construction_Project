using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MenduhInsaat.ViewComponents
{
    public class AdminAboutOnDashBoard:ViewComponent
    {
        Context context = new Context();
        AdminManager adminManager = new AdminManager(new EfAdminRepository());
        private readonly UserManager<AppUser> _userManager;

        public AdminAboutOnDashBoard(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            //var userName = context.Admins.Where(x => x.Username == "Admin").Select(y => y.Name).FirstOrDefault();
            //var user = await _userManager.FindByNameAsync(User.Identity.Name);
            //var usermail = User.Identity.Name;
            //var username = context.Admins.Where(x => x.Username == usermail).Select(y => y.Name).FirstOrDefault();
            //ViewBag.v1 = username;
            var username = User.Identity.Name;
            ViewBag.v1 = username;
            var usermail = context.Admins.Where(x => x.Username == username).Select(y => y.Name).FirstOrDefault();
            var adminID = context.Admins.Where(x => x.Name == usermail).Select(y => y.AdminID).FirstOrDefault();
            var values = adminManager.GetList();
            return View(values);
        }
    }
}
