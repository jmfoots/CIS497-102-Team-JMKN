using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppName.Models
{
    public class Supervisor
    {
        //Primary key
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SupervisorKey { get; set; }

        //Supervisor's user-entered ID
        [Required(ErrorMessage = "Supervisor ID is required.")]
        public string SupervisorID { get; set; }

        //0 = not deleted, 1 = deleted
        [System.ComponentModel.DefaultValue(false)]
        public bool Deleted { get; set; }

        //Supervisor's first name
        [Required(ErrorMessage = "First Name is required.")]
        public string FirstName { get; set; }

        //Supervisor's last name
        [Required(ErrorMessage = "Last Name is required.")]
        public string LastName { get; set; }
    }
}
