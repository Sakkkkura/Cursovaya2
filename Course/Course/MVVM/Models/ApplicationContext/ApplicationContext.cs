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
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Teacher> Teachers { get; set; }

        public ApplicationContext() => Database.EnsureCreated();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            //optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=SAMVVMEF;Trusted_Connection=True;");
            //optionsBuilder.UseSqlServer("Data Source=DESKTOP-I8L1GP6;Initial Catalog=SAMVVMEF;Integrated Security = True");
            optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-4NVEC6K\SQLEXPRESS;Initial Catalog=Schedule");
        }
    }
}
