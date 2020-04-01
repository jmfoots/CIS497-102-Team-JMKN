using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using AppName.Models;

namespace AppName.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            //TODO: Logged in check
            if (true)
            {
                return View("LoggedInView");
            }
            return View("LoggedOutView");
        }
    }
}
