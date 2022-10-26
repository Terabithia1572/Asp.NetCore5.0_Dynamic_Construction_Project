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
    public class OrganizationController : Controller
    {
        OrganizationManager organizationManager = new OrganizationManager(new EfOrganizationRepository());
        public IActionResult Index()
        {
            var values = organizationManager.GetList();
            return View(values);
        }
        public IActionResult OrganizationList()
        {
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
