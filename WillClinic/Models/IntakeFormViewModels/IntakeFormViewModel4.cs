using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WillClinic.Models.IntakeFormViewModels
{
    public class IntakeFormViewModel4
    {
        [Required]
        [Display(Name = "House Hold Size")]
        public int HouseHoldSize { get; set; }

        [Required]
        [Display(Name = "Marital Status")]
        public MaritalStatus MaritalStatus { get; set; }

        [StringLength(50), Required]
        [Display(Name = "Full Name Spouse")]
        public string FullNameSpouse { get; set; }

        [Required]
        [Display(Name = "Have Children")]
        public bool? HaveChildren { get; set; }

        [Required]
        [Display(Name = "Under Age Children")]
        public bool? UnderAgeChildren { get; set; }

        [StringLength(50), Required]
        [Display(Name = "Minor Children Different Spouse")]
        public string MinorChildrenDifferentSpouse { get; set; }

        [Required]
        [Display(Name = "Currently Pregnant")]
        public bool? CurrentlyPregnant { get; set; }

        //public List<VeteranChild> Children { get; set; }

        //public ChildRelationToVeteran ChildRelationToVeteran { get; set; }

        [Required]
        [Display(Name = "Specific Bequest")]
        public bool? SpecificBequest { get; set; }

        [StringLength(500)]
        [Display(Name = "Bequest Information")]
        public string BequestInfromation { get; set; }

        [Display(Name = "Inherit Estate")]
        public InheritEstate InheritEstate { get; set; }

        [StringLength(1000)]
        [Display(Name = "Inherit Estate Specific")]
        public string InheritEstateSpecific { get; set; }

        [Display(Name = "Remainer Beneficiary")]
        public RemainderBeneficiary RemainderBeneficiary { get; set; }

        [StringLength(1000)]
        [Display(Name = "Remainder Beneficiary Specific")]
        public string RemainderBeneficiarySpecific { get; set; }

        [Required]
        [Display(Name = "Disinherit Someone")]
        public bool? DisinheritSomeone { get; set; }

        [StringLength(75)]
        [Display(Name = "Disinheret Description")]
        public string DisinheretDescription { get; set; }

        [StringLength(50)]
        [Display(Name = "Primary Guardian")]
        public string PrimaryGuardian { get; set; }

        [StringLength(50)]
        [Display(Name = "Alternate Guardian")]
        public string AlternateGuardian { get; set; }

        [StringLength(50)]
        [Display(Name = "Personal Representative")]
        public string PersonalRepresentative { get; set; }

        [StringLength(50)]
        [Display(Name = "Alternate Representative")]
        public string AlternateRepresentative { get; set; }
    }
}
