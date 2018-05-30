using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WillClinic.Models
{
    /// <summary>
    /// Represent's a veteran's profile information and relationships for matchmaking. Rows of this
    /// table correspond to rows in the ApplicationUser table via the ApplicationUserId PK/FK column.
    /// </summary>
    public class Veteran
    {
        // NOTE(taylorjoshuaw): Primary key shared with corresponding ApplicationUser entities for this
        //       this table. This can lead to database performance / indexing issues and should probably
        //       be addressed in a future iteration.
        public string ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }

        public string City { get; set; }
        public string State { get; set; }
        public int ZipCode { get; set; }

        // Reference to a veteran lawyer match.
        // NOTE(taylorjoshuaw): This could be made into an ICollection with little effort if needed as it is
        //                      already capable of a many-to-many relationship between veterans and lawyers.
        public VeteranLawyerMatch VetLawMatch { get; set; }
        public ICollection<VeteranChild> Children { get; set; }
        public ICollection<VeteranIntakeForm> IntakeForms { get; set; }

        // Matching via many-to-many relationship to Library entities via the VeteranLibraryJunction table
        public ICollection<VeteranLibraryJunction> VeteranLibraryJunctions { get; set; }
      
        [Obsolete("No longer used. Prioritization of veterans are based on a timestamp stored in the VeteranLibraryJunction table")]
        public VeteranQueue VetQueue { get; set; }
        [Obsolete("Range-based matches are now based on landmarks and should be patched into the veteran's profile along with a range as lat / lon / range as floats.")]
        public string Coordinates { get; set; }
    }
}