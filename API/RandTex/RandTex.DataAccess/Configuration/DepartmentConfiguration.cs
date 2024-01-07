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
    public class DepartmentConfiguration : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name).IsRequired();

            //One to Many Relationship
            builder.HasMany(x => x.Employees)
                   .WithOne(x=>x.Department)
                   .HasForeignKey(x=>x.DepartmentId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
