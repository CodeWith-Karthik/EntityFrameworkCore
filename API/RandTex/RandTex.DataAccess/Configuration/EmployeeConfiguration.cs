using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RandTex.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandTex.DataAccess.Configuration
{
    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            //Primary Key
            builder.HasKey(x => x.Id);

            //Properties 
            builder.Property(x => x.FirstName).IsRequired().HasMaxLength(50);

            builder.Property(x => x.MiddleName).HasMaxLength(50);

            builder.Property(x => x.LastName).IsRequired().HasMaxLength(50);

            builder.Property(x => x.EmployedFrom).IsRequired();

            //One to One Relationship
            builder.HasOne(x => x.EmployeeDetails)
                   .WithOne(x => x.Employee)
                   .HasForeignKey<EmployeeDetails>(x => x.EmployeeId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
