using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MenduhInsaat.ViewComponents
{
    public class Organizations:ViewComponent
    {
        OrganizationManager organizationManager = new OrganizationManager(new EfOrganizationRepository());
        public IViewComponentResult Invoke()
        {
            var values = organizationManager.GetList();
            return View(values);
        }
    }
}
