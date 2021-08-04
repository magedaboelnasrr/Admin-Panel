using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.DAL.Entities;

namespace WebApplication1.DAL.Database
{
    public class Dbcontainer : IdentityDbContext
    {
        public Dbcontainer(DbContextOptions<Dbcontainer> opts) : base(opts)
        {

        }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<District> Districts { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer(@"server =DESKTOP-QSVLA06\SQLEXPRESS ; database = SharpDb; integrated security = true");
        //}

    }
}
