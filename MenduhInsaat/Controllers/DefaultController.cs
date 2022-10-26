using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MenduhInsaat.Controllers
{
    [AllowAnonymous]
    public class DefaultController : Controller
    {
        public PartialViewResult AboutMe()
        {
            return PartialView();
        }

        public PartialViewResult TopBar()
        {
            return PartialView();
        }
        public PartialViewResult WhyUs()
        {
            return PartialView();
        }
        public PartialViewResult UstHeader()
        {
            return PartialView();
        }
        public PartialViewResult Footer()
        {
            return PartialView();
        }
    }
}
