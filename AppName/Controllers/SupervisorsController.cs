using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AppName.Models;
using AppName.ViewModels;
using System.Reflection;

namespace AppName.Controllers
{
    public class SupervisorsController : Controller
    {
        private readonly ConnectionStringClass _cc;

        public SupervisorsController(ConnectionStringClass cc)
        {
            _cc = cc;
        }

        public IActionResult Index()
        {
            //TODO: Role check
            var viewModel = from s in _cc.Supervisor
                            //Note: only showing non-deleted supervisors prevents admin restore of supervisor accounts.
                            //where s.Deleted == false
                            orderby s.FirstName
                            select new SupervisorsListViewModel { Supervisor = s };
            return View(viewModel);
        }

        public IActionResult New()
        {
            //TODO: Role check
            return View("New", new Supervisor {});
        }

        public IActionResult Edit(int id)
        {
            //TODO: Role check
            return View("New", _cc.Supervisor.Find(id));
        }

        [HttpPost]
        public IActionResult Save(Supervisor supervisor, int ID)
        {
            Supervisor sv = _cc.Supervisor.Find(ID) != null ? _cc.Supervisor.Find(ID) : supervisor;
            PropertyInfo[] props = typeof(Supervisor).GetProperties();
            var subgroup = props.Where(p => !p.Name.Contains("SupervisorKey") && p.CanWrite);
            foreach (PropertyInfo property in subgroup)
            {
                property.SetValue(sv, property.GetValue(supervisor) != null ? property.GetValue(supervisor) : "");
            }

            if (_cc.Supervisor.Any(s => s.SupervisorID == sv.SupervisorID && s.SupervisorKey != sv.SupervisorKey)) { ModelState.AddModelError(string.Empty, $"Another supervisor already exists for {sv.SupervisorID} Supervisor ID."); }

            if (ModelState.IsValid == true)
            {
                if (_cc.Supervisor.Find(ID) == null) { _cc.Supervisor.Add(sv); }
                _cc.SaveChanges();
                return RedirectToAction("Index", "Supervisors");
            }
            return View("New", sv);
        }

        public IActionResult Delete(int id)
        {
            var supervisor = _cc.Supervisor.Find(id);
            if (supervisor != null)
            {
                supervisor.Deleted = !supervisor.Deleted;
                _cc.SaveChanges();
            }
            return RedirectToAction("Index", "Supervisors");
        }
    }
}