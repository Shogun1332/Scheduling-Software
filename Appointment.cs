﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C969___Scheduling_Software
{
    public class Appointment : Base
    {
        public int apptCustID { get; set; }
        public int apptUserID { get; set; }
        public string apptTitle { get; set; }
        public string apptDescription { get; set; }
        public string apptLocation { get; set; }
        public string apptContact { get; set; }
        public string apptType { get; set; }
        public string apptURL { get; set; }
        public DateTime startDateTime { get; set; }
        public DateTime endDateTime { get; set; }

        public Appointment() { }
        public Appointment(int id, int custId, int userId, string title, string desc, string loc, string contact, string type, string url, DateTime start, DateTime end, DateTime created, DateTime mod, string createdBy, string modBy)
        {
            Id = id;
            apptCustID = custId;
            apptUserID = userId;
            apptTitle = title;
            apptDescription = desc;
            apptLocation = loc;
            apptContact = contact;
            apptType = type;
            apptURL = url;
            startDateTime = start;
            endDateTime = end;
            Created = created;
            CreatedBy = createdBy;
            Modified = mod;
            ModifiedBy = modBy;
        }

        // These properties were used prior to implementing the base class to inherit common props from
        //public int apptID { get; set; }
        //public DateTime apptCreatedDateTime { get; set; }
        //public string apptCreatedBy { get; set; }
        //public DateTime apptLastUpdateDateTime { get; set; }
        //public string apptLastUpdateBy { get; set; }
    }
}
