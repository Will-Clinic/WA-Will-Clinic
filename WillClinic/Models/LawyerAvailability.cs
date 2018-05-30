using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WillClinic.Models
{
    [Obsolete("Use the LawyerLibraryJunction and LawyerSchedule tables to establish a lawyer's availability rather than this table.")]
    public class LawyerAvailability
    {
        public int ID { get; set; }

        public Lawyer Lawyer { get; set; }
        public string LawyerId { get; set; }

        public DateTime DateTimeBegin { get; set; }
        public DateTime DateTimeEnd { get; set; }

        public RecurringDays RecurringDays { get; set; }

        [Obsolete("Use the DateTimeBegin and DateTimeEnd properties instead of TimeAvailable")]
        public DateTime TimeAvailable { get; set; }
    }

}
