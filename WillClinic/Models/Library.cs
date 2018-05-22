using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WillClinic.Models
{
    public class Library
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Phone { get; set; }
        public string Zip { get; set; }
        //TODO run script to set
        //public GeoLocation Location {get; set; }
        //TODO operating hours -- format? get from where? display to lawyers/vets how?
    }

    public struct GeoLocation
    {
        public decimal Latitude;
        public decimal Longitude;
    }
}
