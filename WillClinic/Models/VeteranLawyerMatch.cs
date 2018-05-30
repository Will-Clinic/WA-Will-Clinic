using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WillClinic.Models
{
    /// <summary>
    /// Represents a matching between a veteran and a lawyer
    /// </summary>
    public class VeteranLawyerMatch
    {
        public int ID { get; set; }
        public string VeteranApplicationUserId { get; set; }
        public Veteran Veteran { get; set; }
        public string LawyerApplicationUserId { get; set; }
        public Lawyer Lawyer { get; set; }

        // Meeting time selected by the lawyer
        public DateTime TimeSelected { get; set; }

        // Has the veteran selected a value?
        // Possibly remove and make TimeSelected nullable
        public bool IsDateTimeApproved { get; set; }

        // Has a meeting location been chosen by a party?
        // Unused
        public string LocationSelected { get; set; }

        // Has a meeting location been agreed upon by both parties?
        // Unused
        public bool IsLocationApproved { get; set; }
    }
}
