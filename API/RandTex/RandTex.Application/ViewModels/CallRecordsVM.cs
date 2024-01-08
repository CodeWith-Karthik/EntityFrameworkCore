using RandTex.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static RandTex.Domain.ApplicationEnums.ApplicationEnum;

namespace RandTex.Application.ViewModels
{
    public class CallRecordsVM
    {
        public int Id { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        public string CallType { get; set; }


        public int EmployeeId { get; set; }

        public string EmployeeName { get; set; }


        public int CustomerId { get; set; }

        public string CustomerName { get; set; }
    }
}
