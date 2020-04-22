using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppName.Models
{
    public class AppUser : IdentityUser<int>
    {
        public int SupervisorKey { get; set; }

        public bool PasswordChanged { get; set; }

        public bool Deleted { get; set; }
    }
}
