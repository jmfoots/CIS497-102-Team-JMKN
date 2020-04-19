using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AppName.Models;
using AppName.ViewModels;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

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
            if (true)
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
            return View("New", new Employee {});
        }

        public IActionResult Edit(int id)
        {
            //TODO: Role check
            return View("New", _cc.Employee.Find(id));
        }
        [HttpPost]
        public IActionResult Save(Employee employee, int ID)
        {
            Employee ep = _cc.Employee.Find(ID) != null ? _cc.Employee.Find(ID) : employee;
            PropertyInfo[] props = typeof(Employee).GetProperties();
            var subgroup = props.Where(p => !p.Name.Contains("EmployeeID") && p.CanWrite);
            foreach (PropertyInfo property in subgroup)
            {
                property.SetValue(ep, property.GetValue(employee) != null ? property.GetValue(employee) : "");
            }

            if (_cc.Supervisor.Find(ep.SupervisorID) == null) { ModelState.AddModelError(string.Empty, $"No supervisor found for {ep.SupervisorID} Supervisor ID."); }

            if (ModelState.IsValid == true)
            {
                if (_cc.Employee.Find(ID) == null) { _cc.Employee.Add(ep); }
                _cc.SaveChanges();
                return RedirectToAction("Index", "Employees");
            }
            return View("New", ep);
        }

        public IActionResult Delete(int id)
        {
            var employee = _cc.Employee.Find(id);
            if (employee != null)
            {
                _cc.Employee.Remove(employee);
                _cc.SaveChanges();
            }
            return RedirectToAction("Index", "Employees");
        }
    }
}