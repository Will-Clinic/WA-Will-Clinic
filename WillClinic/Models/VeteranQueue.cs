using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WillClinic.Models
{
    public class VeteranQueue
    {
        public int ID { get; set; }
        public string VeteranApplicationUserId { get; set; }
        public Veteran Veteran { get; set; }
        public DateTime TimeEnteredQueue { get; set; }
    }
}
