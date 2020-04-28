using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppName.ViewModels
{
    public class SupervisorsListViewModel
    {
        public SupervisorsListViewModel(List<SupervisorsViewModel> Supervisors)
        {
            this.Supervisors = Supervisors;
        }

        public List<SupervisorsViewModel> Supervisors { get; set; }
    }
}
