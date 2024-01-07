using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandTex.Domain.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey(nameof(Department))]
        public int DepartmentId { get; set; }

        public Department Department { get; set; }


        [Required]
        public string FirstName { get; set; }

        public string? MiddleName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Range(1980,2100, ErrorMessage = "Employed year should be between 1980 to 2100 only")]
        public int EmployedFrom { get; set; }

        public virtual EmployeeDetails EmployeeDetails { get; set; }

        public Employee()
        {
            
        }

        public Employee(int departmentId, string firstName, string middlename, string lastName, int employedFrom)
        {
            DepartmentId = departmentId;
            FirstName = firstName;
            MiddleName = middlename;
            LastName = lastName;
            EmployedFrom = employedFrom;
        }
    }
}
