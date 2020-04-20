﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppName.Models
{
    public class Employee
    {
        //Primary key
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EmployeeKey { get; set; }

        //Employee's user-entered ID
        [Required(ErrorMessage = "Employee ID is required.")]
        public string EmployeeID { get; set; }

        //0 = not deleted, 1 = deleted
        [System.ComponentModel.DefaultValue(true)]
        public bool Deleted { get; set; }

        //Employee's first name
        [Required(ErrorMessage = "First Name is required.")]
        public string FirstName { get; set; }

        //Employee's last name
        [Required(ErrorMessage = "Last Name is required.")]
        public string LastName { get; set; }

        //Foreign key reference to Supervisor
        [Required(ErrorMessage = "Supervisor ID is required.")]
        public int SupervisorKey { get; set; }
    }
}
