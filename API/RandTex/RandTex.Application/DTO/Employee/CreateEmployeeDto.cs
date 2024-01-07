using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandTex.Application.DTO.Employee
{
    public class CreateEmployeeDto
    {

        [Required]
        public int DepartmentId { get; set; }


        [Required]
        public string FirstName { get; set; }

        public string? MiddleName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Range(1980, 2100, ErrorMessage = "Employed year should be between 1980 to 2100 only")]
        public int EmployedFrom { get; set; }
    }
}
