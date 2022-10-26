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
    public class OrganizationController : Controller
    {
        OrganizationManager organizationManager = new OrganizationManager(new EfOrganizationRepository());
        public IActionResult Index()
        {
            var values = organizationManager.GetList();
            return View(values);
        }
    }
}
