using FoodStop.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodStop.Configuration
{
    public class BranchConfiguration : IEntityTypeConfiguration<Branch>
    {
        public void Configure(EntityTypeBuilder<Branch> builder)
        {
            builder.HasData(
                new Branch
                {
                    Id = 4,
                    Name = "SpiceFusion Kitchen",
                    Location = "Covai",
                    Phone = 0123456789
                },
                new Branch
                {
                    Id = 5,
                    Name = "SavoryBite Delights",
                    Location = "Dharmapuri",
                    Phone = 0123456789
                },
                new Branch
                {
                    Id = 6,
                    Name = "CrispyCrust Cafe",
                    Location = "Ambur",
                    Phone = 0123456789
                }
                );
        }
    }
}
