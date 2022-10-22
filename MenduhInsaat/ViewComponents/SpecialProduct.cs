using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MenduhInsaat.ViewComponents
{
    public class SpecialProduct:ViewComponent
    {
        SpecialProductManager _specialProductManager = new SpecialProductManager(new EfSpecialProductRepository());
        public IViewComponentResult Invoke()
        {
            var values = _specialProductManager.GetList();
            return View(values);
        }
    }
}
