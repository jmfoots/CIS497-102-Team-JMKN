using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AppName.Models;
using AppName.ViewModels;

namespace AppName.Controllers
{
    public class FormsController : Controller
    {
        private readonly ConnectionStringClass _cc;

        public FormsController(ConnectionStringClass cc)
        {
            _cc = cc;
        }
        public IActionResult Index()
        {
            //TODO: Role check
            if (true)
            {
                var viewModel = from f in _cc.Form
                                where f.Complete == true
                                from e in _cc.Employee
                                where f.Employee == e.EmployeeID
                                from s in _cc.Supervisor
                                where f.CreatedBy == s.SupervisorID
                                orderby e.FirstName
                                select new FormsListViewModel { Form = f, Employee = e, Supervisor = s };
                return View("AdminView", viewModel);
            }
            else
            {
                //TODO: Get ID of user
                var UserID = 1;

                var viewModel = from f in _cc.Form
                                where f.CreatedBy == UserID
                                from e in _cc.Employee
                                where f.Employee == e.EmployeeID
                                from s in _cc.Supervisor
                                where f.CreatedBy == s.SupervisorID
                                orderby e.FirstName, f.Complete
                                select new FormsListViewModel { Form = f, Employee = e, Supervisor = s };
                return View("SupervisorView", viewModel);
            }
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