using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AppName.Models;

namespace AppName.Controllers
{
    public class SupervisorsController : Controller
    {
        public IActionResult Index()
        {
            //TODO: Role check
            return View();
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
        public IActionResult Save(Supervisor supervisor)
        {
            //TODO: Save form
            return RedirectToAction("Index", "Supervisors");
        }
    }
}