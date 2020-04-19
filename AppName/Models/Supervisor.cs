using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppName.Models
{
    public class Supervisor
    {
        //Primary key
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SupervisorID { get; set; }

        //Supervisor's first name
        [Required(ErrorMessage = "First Name is required.")]
        public string FirstName { get; set; }

        //Supervisor's last name
        [Required(ErrorMessage = "Last Name is required.")]
        public string LastName { get; set; }
    }
}
