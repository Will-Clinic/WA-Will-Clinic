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
        [Range(typeof(bool), "false", "true", ErrorMessage = "The field Veteran Status must be checked.")]
        public bool? VeteranStatus { get; set; }

        [Required]
        [Display(Name = "Proof Of Service")]
        [Range(typeof(bool), "false", "true", ErrorMessage = "The field Proof Of Service must be checked.")]
        public bool? ProofOfService { get; set; }

        [Required]
        [Display(Name = "Resident Status")]
        [Range(typeof(bool), "false", "true", ErrorMessage = "The field Resident Status must be checked.")]
        public bool? ResidentStatus { get; set; }

        [Required]
        [Display(Name = "Net Worth")]
        [Range(typeof(bool), "false", "true", ErrorMessage = "The field Net Worth must be checked.")]
        public bool? NetWorth { get; set; }
    }
}
