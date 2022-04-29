using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Course.MVVM.Models.ApplicationContext
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Group> Groups { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Schedule> Schedules { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Week> Weeks { get; set; }

        public ApplicationContext()
            : base() { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer(@"Data Source=PC-232-14\SQLEXPRESS;Initial Catalog=Schedule;Integrated Security = True;User=sa;Password=4321194");
            optionsBuilder.UseSqlServer(@"Data Source=localhost\SQLExpress;Initial Catalog=Schedule;User=U-19;Password=19$RPEe");
        }
    }
}
