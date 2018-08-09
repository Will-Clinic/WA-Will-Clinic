using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WillClinic.Models.IntakeFormViewModels
{
    public class IntakeFormViewModel7
    {
        [Required]
        [Display(Name = "Health Power Of Attorney")]
        public bool? HealthPOA { get; set; }

        [Display(Name = "Primary Health Attorney")]
        public string PrimaryHealthAttorney { get; set; }

        [Display(Name = "Secondary Health Attorney")]
        public string SecondaryHealthAttorney { get; set; }

        [Display(Name = "Save & Exit")]
        public string Exit { get; set; }
    }
}
