using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WillClinic.Models
{
    /// <summary>
    /// Represents a lawyer's profile information and relationships for matchmaking.
    /// Rows of this table correspond to rows in the ApplicationUser table via the
    /// ApplicationUserId PK/FK relationship.
    /// </summary>
    public class Lawyer
    {
        // NOTE(taylorjoshuaw): Primary key shared with corresponding ApplicationUser entities for this
        //       this table. This can lead to database performance / indexing issues and should probably
        //       be addressed in a future iteration.
        public string ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }

        // Used for verification via LawyerVerificationService 
        public int BarNumber { get; set; }

        public string City { get; set; }
        public string Country { get; set; }
        public string State { get; set; }
        public int ZipCode { get; set; }

        // NOTE(taylorjoshuaw): The following three columns are not currently being used. These
        //       could potentially be presented to veterans during the matching process, though
        //       the "OtherLanguages" column would likely be more useful as a string than a bool
        public string PracticeAreas { get; set; }
        public int YearsOfExperience { get; set; }
        public bool OtherLanguages { get; set; }

        // TODO(taylorjoshuaw): These are currently not being checked during the matchmaking process.
        //       This should be addressed ASAP.
        public bool IsVerified { get; set; }
        public bool IsRejected { get; set; }

        // Many-to-one relationships from Availability rows to this table
        public ICollection<LawyerAvailability> Availability { get; set; }
        // Many-to-one relationships from LawyerSchedule rows to this table
        public ICollection<LawyerSchedule> LawyerSchedules { get; set; }
        // Many-to-many relationships from this table to the Library table via the LawyerLibraryJunction table
        public ICollection<LawyerLibraryJunction> LawyerLibraryJunctions { get; set; }
        // One-to-many relationship from this table to rows of the VeteranLawyerMatch table
        public ICollection<VeteranLawyerMatch> VetLawMatches { get; set; }
      
        [Obsolete("Range-based matches are now based on landmarks and should be patched into the lawyer's availability along with a range as lat / lon / range as floats.")]
        public string Coordinates { get; set; }
    }
}
