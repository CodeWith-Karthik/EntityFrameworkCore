using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static RandTex.Domain.ApplicationEnums.ApplicationEnum;

namespace RandTex.Application.ViewModels
{
    public class EmployeeDetailsVM
    {

        public int EmployeeId { get; set; }

        public string FirstName { get; set; }

        public string? MiddleName { get; set; }

        public string LastName { get; set; }

        public int EmployedFrom { get; set; }

        public int DepartmentId { get; set; }

        public string DepartmentName { get; set;}

        public int EmployeeDetailsId { get; set; }

        public int Age { get; set; }

        public Gender Gender { get; set; }

        public long PhoneNo { get; set; }

        public string EmailAddress { get; set; } = string.Empty;

        public string Address { get; set; } = string.Empty;
    }
}
