using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AppName.Models
{
    public class Supervisor
    {
        //Primary key
        [Key]
        public int SupervisorID { get; set; }

        //Supervisor's first name
        public string FirstName { get; set; }

        //Supervisor's last name
        public string LastName { get; set; }
    }
}
