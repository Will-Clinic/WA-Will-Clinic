using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WillClinic.Models.IntakeFormViewModels
{
    public class IntakeFormViewModel2
    {
        [Required]
        [Display(Name = "Veteran Status")]
        public bool? VeteranStatus { get; set; }

        [Required]
        [Display(Name = "Proof Of Service")]
        public bool? ProofOfService { get; set; }

        [Required]
        [Display(Name = "Resident Status")]
        public bool? ResidentStatus { get; set; }

        [Required]
        [Display(Name = "Net Worth")]
        public bool? NetWorth { get; set; }
    }
}
