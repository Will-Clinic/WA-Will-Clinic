using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WillClinic.Models
{
    /// <summary>
    /// Junction table for the many-to-many relationship between Veteran and
    /// Library rows
    /// </summary>
    public class VeteranLibraryJunction
    {
        public string VeteranId { get; set; }
        public Veteran Veteran { get; set; }

        public long LibraryId { get; set; }
        public Library Library { get; set; }

        /// <summary>
        /// The date and time stamp that a veteran selected a library to be used
        /// for prioritization of matchmaking to ensure first-come-first-serve ordering.
        /// </summary>
        public DateTime TimeAdded { get; set; }
    }
}
