﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace JCore.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            //Try to upload to GitHub in home again by JakeChan
            return View();
            //throw new Exception("Exception Page!");
        }
    }
}