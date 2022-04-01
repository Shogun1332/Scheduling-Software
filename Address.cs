using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C969___Scheduling_Software
{
    public class Address : Base
    {
        public string address { get; set; }
        public string address2 { get; set; }
        public int cityID { get; set; }
        public string postalCode { get; set; }
        public string phone { get; set; }



        // Used prior to implementing Base to inherit common properties from
        //public int addressID { get; set; }
        //public DateTime addressCreatedDateTime { get; set; }
        //public string addressCreatedBy { get; set; }
        //public DateTime addressLastModDateTime { get; set; }
        //public string addressLastModBy { get; set; }
    }
}
