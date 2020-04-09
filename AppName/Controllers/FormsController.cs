﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AppName.Models;

namespace AppName.Controllers
{
    public class FormsController : Controller
    {
        public IActionResult Index()
        {
            //TODO: Role check
            if (false)
            {
                return View("AdminView");
            }
            return View("SupervisorView");
        }

        public IActionResult New()
        {
            //TODO: Role check
            return View();
        }

        public IActionResult Edit()
        {
            //TODO: Role check
            //TODO: Load information
            return View("New");
        }

        [HttpPost]
        public IActionResult Save(Form form)
        {
            //TODO: Save form
            return RedirectToAction("Index", "Forms");
        }

        //TODO: Export form and open in new tab
        /*public IActionResult Export()
        {
            return View();
        }*/
    }
}