﻿using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    public class CustomerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
