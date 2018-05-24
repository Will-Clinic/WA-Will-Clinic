using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WillClinic.Models
{
    public class LawyerSchedule
    {
        public long ID { get; set; }

        public string LawyerId { get; set; }
        public Lawyer Lawyer { get; set; }

        public DateTime TimeBegin { get; set; }
        public DateTime TimeEnd { get; set; }

        public RecurringDays RecurringDays { get; set; }
    }
}
