using Microsoft.EntityFrameworkCore;
using RandTex.DataAccess.Configuration;
using RandTex.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandTex.DataAccess.Common
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new EmployeeConfiguration());
            modelBuilder.ApplyConfiguration(new DepartmentConfiguration());
        }

        public DbSet<Department> Department { get; set; }

        public DbSet<Employee> Employee { get; set; }

        public DbSet<EmployeeDetails> EmployeeDetails { get; set; }
    }
}
