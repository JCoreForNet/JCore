﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace JCore.Controllers
{
    public class SharedController : Controller
    {
        public IActionResult Error()
        {
            return View();
        }
    }
}