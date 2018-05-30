using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WillClinic.Models
{
    /// <summary>
    /// Represents libraries at which veterans veterans and attorneys can meet. This table is seeded
    /// at application start if empty via the WillClinic.Data.SeedLibraries.Initialize() method.
    /// </summary>
    public class Library
    {
        // NOTE(taylorjoshuaw): This primary key was made long when it was initially thought that any
        //                      public location could be selected rather than just libraries. It would
        //                      be safe to drop the Library table and re-seed with the ID as an int if needed.
        public long ID { get; set; }

        [Required]
        public string Name { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        [DataType(DataType.PostalCode)]
        public string ZipCode { get; set; }
        [Required]
        [Phone]
        public string Phone { get; set; }

        // Many-to-many relationships with lawyers and veterans via their respective junction tables
        public ICollection<LawyerLibraryJunction> LawyerLibraryJunctions { get; set; }
        public ICollection<VeteranLibraryJunction> VeteranLibraryJunctions { get; set; }

        // TODO(taylorjoshuaw): Range-based matching could potentially result in a large number of geocode
        //                      requests to the chosen mapping API. These should be cached in the library
        //                      table during the seeding process in a format convenient for distance
        //                      calculations (a .NET Core equivalent to the .NET Framework GeoCoordinate
        //                      class would be a good place to start)
    }
}
