using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandTex.Application.DTO.Department
{
    public class CreateDepartmentDto
    {
        [Required]
        public string Name { get; set; }
    }
}
