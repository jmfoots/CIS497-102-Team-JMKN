using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AppName.Models
{
    public class PasswordModel
    {
        public PasswordModel() { }

        public PasswordModel(string OldPassword, string NewPassword, string NewPasswordConfirm)
        {
            this.OldPassword = OldPassword;
            this.NewPassword = NewPassword;
            this.NewPasswordConfirm = NewPasswordConfirm;
        }

        //Old password
        [MaxLength(20)]
        public string OldPassword { get; set; }

        //New password
        [MaxLength(20)]
        public string NewPassword { get; set; }

        //Confirm new password
        [MaxLength(20)]
        public string NewPasswordConfirm { get; set; }
    }
}
