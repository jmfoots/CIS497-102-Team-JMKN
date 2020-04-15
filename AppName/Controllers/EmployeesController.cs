using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AppName.Models;
using AppName.ViewModels;

namespace AppName.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly ConnectionStringClass _cc;

        public EmployeesController(ConnectionStringClass cc)
        {
            _cc = cc;
        }
        public IActionResult Index()
        {
            //TODO: Role check
            if (false)
            {
                var viewModel = from e in _cc.Employee
                                join s in _cc.Supervisor on e.SupervisorID equals s.SupervisorID
                                orderby e.FirstName
                                select new EmployeesListViewModel { Employee = e, Supervisor = s };

                return View("AdminView", viewModel);
            }
            else
            {
                //TODO: Get ID of user
                var UserID = 1;

                var viewModel = from e in _cc.Employee
                                join s in _cc.Supervisor on e.SupervisorID equals s.SupervisorID
                                where s.SupervisorID == UserID
                                orderby e.FirstName
                                select new EmployeesListViewModel { Employee = e, Supervisor = s };
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
            //TODO: Load information
            return View("New");
        }

        [HttpPost]
        public IActionResult Save(Employee employee)
        {
            //TODO: Save form
            return RedirectToAction("Index", "Employees");
        }
    }
}