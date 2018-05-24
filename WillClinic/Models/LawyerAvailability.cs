using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WillClinic.Models
{
    public class LawyerAvailability
    {
        public int ID { get; set; }

        public Lawyer Lawyer { get; set; }
        public string LawyerId { get; set; }

        //public ICollection<LibraryAvailabilityJunction> LibraryAvailabilityJunctions { get; set; }

        public DateTime DateTimeBegin { get; set; }
        public DateTime DateTimeEnd { get; set; }

        public RecurringDays RecurringDays { get; set; }

        [Obsolete("Use the DateTimeBegin and DateTimeEnd properties instead of TimeAvailable")]
        public DateTime TimeAvailable { get; set; }
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
