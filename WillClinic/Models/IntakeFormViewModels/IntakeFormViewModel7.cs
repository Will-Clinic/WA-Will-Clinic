using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WillClinic.Models.IntakeFormViewModels
{
    public class IntakeFormViewModel7
    {
        [Display(Name = "Health Power Of Attorney")]
        [Range(typeof(bool?), "false", "true", ErrorMessage = "The field Health Power Of Attorney must be checked.")]
        public bool? HealthPOA { get; set; }

        [Display(Name = "Primary Health Attorney")]
        public string PrimaryHealthAttorney { get; set; }

        [Display(Name = "Secondary Health Attorney")]
        public string SecondaryHealthAttorney { get; set; }
    }
}
