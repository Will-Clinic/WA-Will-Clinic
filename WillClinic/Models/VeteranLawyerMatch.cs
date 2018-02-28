using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WillClinic.Models
{
    public class VeteranLawyerMatch
    {
        public int ID { get; set; }
        public string VeteranApplicationUserId { get; set; }
        public Veteran Veteran { get; set; }
        public string LawyerApplicationUserId { get; set; }
        public Lawyer Lawyer { get; set; }

        public DateTime TimeSelected { get; set; }
        public string LocationSelected { get; set; }
        public bool IsDateTimeApproved { get; set; }
        public bool IsLocationApproved { get; set; }
    }
}
