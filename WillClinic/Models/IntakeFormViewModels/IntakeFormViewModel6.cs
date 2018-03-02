using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WillClinic.Models.IntakeFormViewModels
{
    public class IntakeFormViewModel6
    {
        [Required]
        [Display(Name = "Health Care Directive")]
        public bool? HealthCareDirective { get; set; }

        [Required]
        [Display(Name = "Hydration Directive")]
        public bool? HydrationDirective { get; set; }

        [Required]
        [Display(Name = "Nutrition Directive")]
        public bool? NutritionDirective { get; set; }

        [Required]
        [Display(Name = "Artificial Ventilation")]
        public bool? ArtificialVentilation { get; set; }

        [Required]
        [Display(Name = "Distress Medication")]
        public bool? DistressMedication { get; set; }
    }
}
