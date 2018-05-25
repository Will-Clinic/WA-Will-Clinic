using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WillClinic.Models
{
    public class VeteranLibraryJunction
    {
        public string VeteranId { get; set; }
        public Veteran Veteran { get; set; }

        public long LibraryId { get; set; }
        public Library Library { get; set; }

        public DateTime TimeAdded { get; set; }
    }
}
