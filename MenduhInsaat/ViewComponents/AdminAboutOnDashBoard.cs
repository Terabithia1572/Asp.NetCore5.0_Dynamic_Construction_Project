using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
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
        public IViewComponentResult Invoke()
        {
            //var userName = context.Admins.Where(x => x.Username == "Admin").Select(y => y.Name).FirstOrDefault();
            var values = adminManager.GetList();
            return View(values);
        }
    }
}
