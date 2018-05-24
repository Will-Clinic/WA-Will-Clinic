using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WillClinic.Models
{
    public class LawyerLibraryJunction
    { 
        public string LawyerId { get; set; }
        public Lawyer Lawyer { get; set; }

        public long LibraryId { get; set; }
        public Library Library { get; set; }
    }
}
