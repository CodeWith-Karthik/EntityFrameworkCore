using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static RandTex.Domain.ApplicationEnums.ApplicationEnum;

namespace RandTex.Domain.Models
{
    public class EmployeeDetails
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey(nameof(Employee))]
        public int EmployeeId { get; set; }

        public Employee Employee { get; set; }  

        public int Age { get; set; }

        public Gender Gender { get; set; }  

        public long PhoneNo { get; set; }

        public string EmailAddress { get; set; }
        public string Address { get; set; }

        public EmployeeDetails()
        {
            
        }

        public EmployeeDetails(int employeeId, int age, Gender gender, long phoneNo, string emailAddress, string address)
        {
            EmployeeId = employeeId;
            Age = age;
            Gender = gender;
            PhoneNo = phoneNo;
            EmailAddress = emailAddress;
            Address = address;
        }

    }
}
