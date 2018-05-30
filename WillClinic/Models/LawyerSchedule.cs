using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WillClinic.Models
{
    /// <summary>
    /// Represents a day / time availability for a lawyer to meet with veterans.
    /// </summary>
    public class LawyerSchedule
    {
        public long ID { get; set; }

        public string LawyerId { get; set; }
        public Lawyer Lawyer { get; set; }

        // Stores the time that this scheduling begins in UTC. For non-recurring schedules
        // (schedules on a specific date), this also stores the date for this scheduled availability
        public DateTime TimeBegin { get; set; }
        // Stores the time that this scheduling ends in UTC.
        public DateTime TimeEnd { get; set; }

        // Stores the recurrence of this scheduling. Note that the RecurringDays enumeration has
        // the Flags attribute applied to it, meaning that values can be OR combined together along
        // with other boolean operations. If the scheduling is for a specific date, then this should
        // be set to RecurringDays.None (0x00)
        public RecurringDays RecurringDays { get; set; }
    }

    /// <summary>
    /// Used to specify which days of the week the availability is recurring.
    /// These can be OR combined, such as (Sunday | Wednesday | Friday); as
    /// such, all values in this enumeration must be powers of 2. These are stored
    /// as bytes on the database, for example: Sunday | Wednesday | Friday = 0x29 (0010 1001)
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
