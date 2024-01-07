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
    public class CallRecordsConfiguration : IEntityTypeConfiguration<CallRecords>
    {
        public void Configure(EntityTypeBuilder<CallRecords> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.StartTime).IsRequired();
            builder.Property(x => x.EndTime).IsRequired();
            builder.Property(x => x.CallType).IsRequired();

            //Many to Many
            builder.HasOne(x=>x.Employee).WithMany(x=>x.CallRecords).HasForeignKey(x=>x.EmployeeId);
            builder.HasOne(x=>x.Customer).WithMany(x=>x.CallRecords).HasForeignKey(x=>x.CustomerId);

        }
    }
}
