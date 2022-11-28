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
   
    public class OrganizationController : Controller
    {
        OrganizationManager organizationManager = new OrganizationManager(new EfOrganizationRepository());
        AdminManager adminManager = new AdminManager(new EfAdminRepository());
        Context context = new Context();
        [AllowAnonymous]
        public IActionResult Index()
        {
            var values = organizationManager.GetList();
            return View(values);
        }
       
        public IActionResult OrganizationList()
        {
            var username = User.Identity.Name;
            ViewBag.v1 = username;
            var usermail = context.Admins.Where(x => x.Username == username).Select(y => y.Name).FirstOrDefault();
            var userDescription = context.Admins.Where(x => x.Username == username).Select(y => y.ShortDescription).FirstOrDefault();
            var adminID = context.Admins.Where(x => x.Name == usermail).Select(y => y.AdminID).FirstOrDefault();
            ViewBag.v2 = usermail;
            ViewBag.v3 = userDescription.Substring(0, 23);
            var values = organizationManager.GetList();
            return View(values);
        }
        [HttpGet]
        public IActionResult AddOrganization()
        {

            return View();
        }
        [HttpPost]
        public IActionResult AddOrganization(Organization organization)
        {


            organizationManager.TAdd(organization);
            return RedirectToAction("OrganizationList", "Organization");
        }

        public IActionResult DeleteOrganization(int id)
        {
            var organizationvalue = organizationManager.TGetByID(id);
            organizationManager.TDelete(organizationvalue);
            return RedirectToAction("OrganizationList", "Organization");
        }
        [HttpGet]
        public IActionResult EditOrganization(int id)
        {

            var organizationvalue = organizationManager.TGetByID(id);

            return View(organizationvalue);
        }
        [HttpPost]

        public IActionResult EditOrganization(Organization organization)
        {


          
         
            organizationManager.TUpdate(organization);
            return RedirectToAction("OrganizationList", "Organization");
        }
    }
}
