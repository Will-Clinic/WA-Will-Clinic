 using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WillClinic.Models
{
    public class VeteranChildren
    {
        public int ID { get; set; }

        public Veteran Parent { get; set; }

        [StringLength(50), Required]
        public string VeteranModelApplicationUserId { get; set; }

        [StringLength(50), Required]
        public string FullName { get; set; }

        public DateTime DOB { get; set; }

        [StringLength(50), Required]
        public string Lineage { get; set; }

        [StringLength(50), Required]
        public string MotherOfChildName { get; set; }


    }
}
