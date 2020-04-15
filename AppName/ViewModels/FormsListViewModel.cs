using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppName.Models;

namespace AppName.ViewModels
{
    public class FormsListViewModel
    {
        public Form Form { get; set; }

        public Supervisor Supervisor { get; set; }

        public Employee Employee { get; set; }
    }
}
