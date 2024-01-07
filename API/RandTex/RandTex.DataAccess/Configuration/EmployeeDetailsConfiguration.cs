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
    public class EmployeeDetailsConfiguration : IEntityTypeConfiguration<EmployeeDetails>
    {
        public void Configure(EntityTypeBuilder<EmployeeDetails> builder)
        {
            //Primary key
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Age).IsRequired();
            builder.Property(x => x.Gender).IsRequired();
            builder.Property(x => x.PhoneNo).IsRequired();
            builder.Property(x => x.EmailAddress);
            builder.Property(x => x.Address).IsRequired();
        }
    }
}
