using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WillClinic.Models.VeteranModels;

namespace WillClinic.Models
{
    public class Veteran
    {
        public int Id { get; set; }
        public string ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int ZipCode { get; set; }
        public PrimaryData PrimaryData { get; set; }
        public VeteranNetWorth VeteranNetWorth { get; set; }
        public PowerOfAttorney PowerOfAttorney { get; set; }

        // Those ICollections exist for the purpose of Fluent API to enable the one-to-many relationship
        public VeteranLawyerMatch VetLawMatch { get; set; }
        public VeteranQueue VetQueue { get; set; }
        public ICollection<VeteranChild> Children { get; set; }
        public ICollection<VeteranIntakeForm> IntakeForms { get; set; }

        // Matching via many-to-many relationship to Library entities
        public ICollection<VeteranLibraryJunction> VeteranLibraryJunctions { get; set; }
      
        // These coordinates are not the veteran's exact location but are the coordinates returned to a google API request based on the zip code.
        public string Coordinates { get; set; }
    }
}