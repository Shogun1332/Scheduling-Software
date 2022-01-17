using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C969___Scheduling_Software
{
    public class Customer
    {
        public int customerID { get; set; }
        public string customerName { get; set; }
        public int customerAddressID { get; set; }
        public byte customerActive { get; set; }
        public DateTime customerCreatedDateTime { get; set; }
        public string customerCreatedBy { get; set; }
        public DateTime customerLastModDateTime { get; set; }
        public string customerLastModBy { get; set; }
    }
}
