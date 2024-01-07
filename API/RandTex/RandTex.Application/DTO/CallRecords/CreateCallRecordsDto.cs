using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static RandTex.Domain.ApplicationEnums.ApplicationEnum;

namespace RandTex.Application.DTO.CallRecords
{
    public class CreateCallRecordsDto
    {
        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        public CallType CallType { get; set; }

        public int EmployeeId { get; set; }

        public int CustomerId { get; set; }
    }
}
