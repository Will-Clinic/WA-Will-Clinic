using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WillClinic.Models
{
    public class Veteran
    {
        public string ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int ZipCode { get; set; }

        // Those ICollections exist for the purpose of Fluent API to enable the one-to-many relationship
        public ICollection<VeteranChild> Children { get; set; }
        public ICollection<VeteranIntakeForm> IntakeForms { get; set; }
    }
}