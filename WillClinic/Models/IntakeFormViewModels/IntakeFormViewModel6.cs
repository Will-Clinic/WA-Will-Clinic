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
        [Range(typeof(bool), "false", "true", ErrorMessage = "The field Health Care Directive must be checked.")]
        public bool? HealthCareDirective { get; set; }

        [Required]
        [Display(Name = "Hydration Directive")]
        [Range(typeof(bool), "false", "true", ErrorMessage = "The field Hydration Directive must be checked.")]
        public bool? HydrationDirective { get; set; }

        [Required]
        [Display(Name = "Nutrition Directive")]
        [Range(typeof(bool), "false", "true", ErrorMessage = "The field Nutrition Directive must be checked.")]
        public bool? NutritionDirective { get; set; }

        [Required]
        [Display(Name = "Artificial Ventilation")]
        [Range(typeof(bool), "false", "true", ErrorMessage = "The field Artificial Ventilation must be checked.")]
        public bool? ArtificialVentilation { get; set; }

        [Required]
        [Display(Name = "Distress Medication")]
        [Range(typeof(bool), "false", "true", ErrorMessage = "The field Distress Medication must be checked.")]
        public bool? DistressMedication { get; set; }
    }
}
