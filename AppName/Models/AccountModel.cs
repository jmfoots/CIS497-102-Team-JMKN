using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppName.Models
{
    public class AccountModel
    {
        public AccountModel(string Email)
        {
            this.Email = Email;
        }

        //User's email address
        public string Email { get; set; }
    }
}
