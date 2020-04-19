using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppName.Models
{
    public class Employee
    {
        //Primary key
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EmployeeID { get; set; }

        //Employee's first name
        [Required(ErrorMessage = "First Name is required.")]
        public string FirstName { get; set; }

        //Employee's last name
        [Required(ErrorMessage = "Last Name is required.")]
        public string LastName { get; set; }

        //Foreign key reference to Supervisor
        [Required(ErrorMessage = "Supervisor ID is required.")]
        public int SupervisorID { get; set; }
    }
}
