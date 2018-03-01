using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WillClinic.Models
{
    public class VeteranChild
    {
        public int ID { get; set; }

        public Veteran Veteran { get; set; }

        [StringLength(50), Required]
        public string MotherOfChildName { get; set; }

        public string VeteranApplicationUserId { get; set; }

        [StringLength(50), Required]
        public string FullName { get; set; }

        public DateTime DOB { get; set; }

        [Required]
        public ChildRelationToVeteran ChildRelationToVeteran { get; set; }
    }
}
