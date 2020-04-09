using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AppName.Models
{
    public class Employee
    {
        //Primary key
        public int Id { get; set; }

        //Employee's first name
        public string FirstName { get; set; }

        //Employee's last name
        public string LastName { get; set; }

        //Foreign key reference to Supervisor
        public Supervisor Supervisor { get; set; }
    }
}
