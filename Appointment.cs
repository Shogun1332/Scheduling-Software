using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C969___Scheduling_Software
{
    public class Appointment
    {
        public string apptTitle { get; set; }
        public string apptLocation { get; set; }
        public int apptID { get; set; }
        public int apptCustID { get; set; }
        public int apptUserID { get; set; }
        public string apptDescription { get; set; }
        public string apptContact { get; set; }
        public string apptType { get; set; }
        public string apptURL { get; set; }
        public string apptCreatedBy { get; set; }
        public string apptLastUpdateBy { get; set; }
        public DateTime startDateTime { get; set; }
        public DateTime endDateTime { get; set; }
        public DateTime apptCreatedDateTime { get; set; }
        public DateTime apptLastUpdateDateTime { get; set; }
    }
}
