using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C969___Scheduling_Software
{
    public class City
    {
        public int cityID { get; set; }
        public string city { get; set; }
        public int countryID { get; set; }
        public DateTime cityCreatedDateTime { get; set; }
        public string cityCreatedBy { get; set; }
        public DateTime cityLastModDateTime { get; set; }
        public string cityLastModBy { get; set; }
    }
}
