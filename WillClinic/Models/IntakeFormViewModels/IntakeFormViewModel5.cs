using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WillClinic.Models.IntakeFormViewModels
{
    public class IntakeFormViewModel5
    {
        [Required]
        [Display(Name = "Request Power Of Attorney")]
        public bool? RequestPowerOfAttorney { get; set; }

        [StringLength(50)]
        [Display(Name = "Primary Attorney")]
        public string PrimaryAttorney { get; set; }

        [StringLength(50)]
        [Display(Name = "Alternate Attorney")]
        public string AlternateAttorney { get; set; }
    }
}
