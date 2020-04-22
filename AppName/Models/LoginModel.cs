using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AppName.Models
{
    public class LoginModel
    {
        //Email used to login
        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Not a valid email address.")]
        public string Email { get; set; }

        //User password
        [Required(ErrorMessage = "Password is required.")]
        public string Password { get; set; }
    }
}
