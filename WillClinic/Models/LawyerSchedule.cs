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

    /// <summary>
    /// Used to specify which days of the week the availability is recurring.
    /// These can be OR combined, such as (Sunday | Wednesday | Friday); as
    /// such, all values in this enumeration must be powers of 2.
    /// </summary>
    [Flags]
    public enum RecurringDays : byte
    {
        None = 0,
        Sunday = 1,
        Monday = 2,
        Tuesday = 4,
        Wednesday = 8,
        Thursday = 16,
        Friday = 32,
        Saturday = 64
    }
}
