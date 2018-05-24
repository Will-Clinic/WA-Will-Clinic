using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WillClinic.Models
{
    public class LibraryAvailabilityJunction
    {
        public Library Library { get; set; }
        public long LibraryId { get; set; }

        public LawyerAvailability LawyerAvailability { get; set; }
        public int LawyerAvailabilityId { get; set; }
    }
}
