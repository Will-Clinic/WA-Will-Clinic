using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WillClinic.Models.IntakeFormViewModels
{
    public class IntakeFormViewModel0
    {
        [Required]
        [Display(Name = "Terms and Conditions")]
        public bool? TermsAndConditions { get; set; }

    }
}
