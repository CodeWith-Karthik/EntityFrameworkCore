using RandTex.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandTex.DataAccess.Common
{
    public class SeedData
    {
        public static async Task SeedDataAsync(ApplicationDbContext _dbContext)
        {
            if (!_dbContext.Department.Any())
            {
                _dbContext.Department.AddRange(
                    new Department { Name = "HR" },
                    new Department { Name = "Sales" },
                    new Department { Name = "Marketing" },
                    new Department { Name = "Research & Development" }
                    );

               await _dbContext.SaveChangesAsync();
            }
        }
    }
}
