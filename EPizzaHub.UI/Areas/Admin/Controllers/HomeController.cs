﻿using Microsoft.AspNetCore.Mvc;

namespace EPizzaHub.UI.Areas.Admin.Controllers
{

    
    public class HomeController : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
