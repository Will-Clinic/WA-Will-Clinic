using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WillClinic.Models
{
    /// <summary>
    /// Junction table for the many-to-many relationship between Lawyer and Library
    /// table rows.
    /// </summary>
    public class LawyerLibraryJunction
    { 
        public string LawyerId { get; set; }
        public Lawyer Lawyer { get; set; }

        public long LibraryId { get; set; }
        public Library Library { get; set; }
    }
}
