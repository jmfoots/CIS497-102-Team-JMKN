using System;
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
            //TODO: Load information into form
            return View("New");
        }

        [HttpPost]
        public IActionResult Save(Form form)
        {
            //TODO: Save form
            //Check completion and set Complete appropriately
            //If completed and new form: Set Deleted = 0, set CreatedBy, set Id, calculate and set averages
            //If completed and edited form: Calculate and set averages
            //If incomplete and new form: Set Deleted = 0, set CreatedBy, set Id, leave averages unset
            //If incomplete and edited form: Leave averages unset
            return RedirectToAction("Index", "Forms");
        }

        //TODO: Export form and open in new tab
        /*public IActionResult Export()
        {
            return View();
        }*/
    }
}