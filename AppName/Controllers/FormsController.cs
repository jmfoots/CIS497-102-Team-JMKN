using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using AppName.Models;
using AppName.ViewModels;
using System.Reflection;
using Microsoft.EntityFrameworkCore.Internal;

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
                                //where f.Complete == true
                                //where f.Deleted == false
                                from e in _cc.Employee
                                where f.Employee == e.EmployeeID
                                from s in _cc.Supervisor
                                where f.CreatedBy == s.SupervisorID
                                orderby e.FirstName
                                select new FormsListViewModel { Form = f, Employee = e, Supervisor = s };
                return View("SupervisorView", viewModel);
            }
            else
            {
                //TODO: Get ID of user
                var UserID = 1;

                var viewModel = from f in _cc.Form
                                where f.CreatedBy == UserID
                                where f.Deleted == false
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
            return View("New", new Form {});
        }

        public IActionResult Edit(int id)
        {
            //TODO: Role check
            return View("New", _cc.Form.Find(id));
        }

        [HttpPost]
        public IActionResult Save(Form edits, int ID)
        {
            Form form = _cc.Form.Find(ID) ?? edits;
            PropertyInfo[] props = typeof(Form).GetProperties();
            var subgroup = props.Where(p => !p.Name.Contains("FormID") && !p.Name.Contains("SupervisorID") && p.CanWrite);
            foreach (PropertyInfo property in subgroup)
            {
                property.SetValue(form, property.GetValue(edits) != null ? property.GetValue(edits) : "");
            }

            if (_cc.Employee.Find(edits.Employee) != null) { form.CreatedBy = _cc.Employee.Find(edits.Employee).SupervisorID; } else { ModelState.AddModelError(string.Empty, $"No employee found for {edits.Employee} Employee ID."); }
            if (_cc.Form.Any(u => u.Employee == edits.Employee && u.FormID != form.FormID)) { ModelState.AddModelError(string.Empty, $"Another form already exists for {edits.Employee} Employee ID."); }

            form.Complete = evaluateComplete(form);
            if (form.Complete == true)
            {
                string[] groups = { "Communication", "Appreciation", "Development", "Teamwork" };
                foreach (string group in groups)
                {
                    var property = props.Where(p => p.Name.Contains(group) && p.PropertyType == typeof(decimal)).FirstOrDefault();
                    property.SetValue(form, getAvgProperties(group, form));
                }
            }

            if (ModelState.IsValid == true)
            {
                if (_cc.Form.Find(ID) == null) { _cc.Form.Add(form); }
                _cc.SaveChanges();
                return RedirectToAction("Index", "Forms");
            }
            return View("New", form);
        }
        bool evaluateComplete(Form form)
        {
            PropertyInfo[] props = typeof(Form).GetProperties();
            var integers = props.Where(p => p.PropertyType == typeof(int));
            foreach (PropertyInfo property in integers)
            {
                if ((int) property.GetValue(form) == 0) { return false;  }
            }
            var strings = props.Where(p => p.PropertyType == typeof(string));
            foreach (PropertyInfo property in strings)
            {
                if (property.GetValue(form).ToString().Length == 0 ) { return false; }
            }
            return true;
        }
        decimal getAvgProperties(string root, Form form)
        {
            PropertyInfo[] props = typeof(Form).GetProperties();
            var subgroup = props.Where(p => p.Name.Contains(root));
            Decimal avg = 0;
            foreach (PropertyInfo property in subgroup)
            {
                if (property.PropertyType == typeof(int))
                {
                    avg += (int)property.GetValue(form);
                }
            }
            return avg / (subgroup.Count()-1);
        }
        
        public IActionResult Delete(int id)
        {
            //TODO: Role check
            var form = _cc.Form.Find(id);
            if (form != null)
            {
                form.Deleted = !form.Deleted;
                _cc.SaveChanges();
            }
            return RedirectToAction("Index", "Forms");
        }
        //TODO: Export form and open in new tab
        /*public IActionResult Export()
        {
            return View();
        }*/
    }
}