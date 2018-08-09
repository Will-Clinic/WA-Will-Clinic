using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WillClinic.Models.IntakeFormViewModels
{
    public class IntakeFormViewModel1
    {
        //[Required]
        [StringLength(50)]
        [Display(Name = "Full Legal Name")]
        public string FullLegalName { get; set; }

        //[Required]
        [StringLength(50)]
        public string Address { get; set; }

        //[Required]
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }

        [Display(Name = "Save & Exit")]
        public string Exit { get; set; }
    }
}
