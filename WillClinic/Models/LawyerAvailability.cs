using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WillClinic.Models
{
    public class LawyerAvailability
    {
        public int ID { get; set; }
        public string LawyerApplicationUserId { get; set; }
        public Lawyer Lawyer { get; set; }
        public DateTime TimeAvailable { get; set; }
    }
}
