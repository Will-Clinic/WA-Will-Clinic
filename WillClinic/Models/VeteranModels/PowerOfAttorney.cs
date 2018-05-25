using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WillClinic.Models.VeteranModels
{
    public class PowerOfAttorney
    {
        public int Id { get; set; }
        public string PrimaryAttorney { get; set; }
        public string AlternateAttorney { get; set; }
    }
}
