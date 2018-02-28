using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WillClinic.Models
{
    public class Lawyer
    {
        public string ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }

        public int BarNumber { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string State { get; set; }
        public int ZipCode { get; set; }
        public string PracticeAreas { get; set; }
        public int YearsOfExperience { get; set; }
        public bool OtherLanguages { get; set; }

        // These coordinates are not the lawyer's exact location but are the coordinates returned to a google API request based on the zip code.
        public string Coordinates { get; set; }
    }
}
