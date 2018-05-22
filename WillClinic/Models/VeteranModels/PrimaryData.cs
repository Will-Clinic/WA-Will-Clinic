using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WillClinic.Models.VeteranModels
{
    public class PrimaryData
    {
        public int Id { get; set; }
        public string FullLegalName { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public bool? VeteranStatus { get; set; }
        public bool? ProofOfService { get; set; }
        public bool? ResidentStatus { get; set; }
        public bool? NetWorth { get; set; }
    }
}
