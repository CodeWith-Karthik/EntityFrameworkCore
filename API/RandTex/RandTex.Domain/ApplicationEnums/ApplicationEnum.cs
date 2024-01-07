using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandTex.Domain.ApplicationEnums
{
    public class ApplicationEnum
    {
        public enum Gender
        {
            Male = 0,
            Female = 1,
            Others = 2
        }

        public enum CallType
        {
            Incoming = 0,
            Outgoing = 1,
        }
    }
}
