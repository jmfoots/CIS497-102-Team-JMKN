using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppName.Models
{
    public class Supervisor
    {
        //Primary key
        public int Id { get; set; }

        //Supervisor's first name
        public string FirstName { get; set; }

        //Supervisor's last name
        public string LastName { get; set; }
    }
}
