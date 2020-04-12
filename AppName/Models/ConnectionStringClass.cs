using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace AppName.Models
{
    public class ConnectionStringClass : DbContext
    {

        public ConnectionStringClass(DbContextOptions<ConnectionStringClass> options) : base(options)
        {

        }

        public DbSet<Employee> Employee { get; set; }

        public DbSet<Supervisor> Supervisor { get; set; }

        public DbSet<Form> Form { get; set; }
    }
}