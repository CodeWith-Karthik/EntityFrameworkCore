using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandTex.Domain.Models
{
    public class Customer
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<CallRecords> CallRecords { get; set; }

        public Customer()
        {
            
        }

        public Customer(string name)
        {
            Name = name;
        }
    }
}
