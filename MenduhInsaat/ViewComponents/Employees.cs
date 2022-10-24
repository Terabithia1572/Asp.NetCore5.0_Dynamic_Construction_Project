using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MenduhInsaat.ViewComponents
{
    public class Employees:ViewComponent
    {
        EmployeeManager employeeManager = new EmployeeManager(new EfEmployeeRepository());
        public IViewComponentResult Invoke()
        {
            var values = employeeManager.GetList();
            return View(values);
        }
    }
}
