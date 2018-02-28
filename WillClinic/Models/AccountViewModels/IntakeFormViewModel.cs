using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WillClinic.Models.AccountViewModels
{
    public class IntakeFormViewModel
    {
        public int ID { get; set; }

        public string VeteranApplicationUserId { get; set; }

        [Required]
        public bool IsNotarized { get; set; }

        [Required]
        public byte CurrentStep { get; set; }

        [Required]
        public DateTime TimeStamp { get; set; }

        [Required]
        [Display(Name = "Terms and Conditions")]
        public bool TermsAndConditions { get; set; }

        [StringLength(50), Required]
        [Display(Name = "Full Legal Name")]
        public string FullLegalName { get; set; }

        [StringLength(50), Required]
        public string Address { get; set; }

        [Required]
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }

        [Required]
        [Display(Name = "Veteran Status")]
        public bool VeteranStatus { get; set; }

        [Required]
        [Display(Name = "Proof Of Service")]
        public bool ProofOfService { get; set; }

        [Required]
        [Display(Name = "ResidentStatus")]
        public bool ResidentStatus { get; set; }

        [Required]
        [Display(Name = "Net Worth")]
        public bool NetWorth { get; set; }

        [Required]
        [Display(Name = "Bank Account Assets")]
        public int BankAccountAssets { get; set; }

        [Required]
        [Display(Name = "Real Estate Assets")]
        public int RealEstateAssets { get; set; }

        [Required]
        [Display(Name = "Life Insurance Cash Value")]
        public int LifeInsuranceCashValue { get; set; }

        [Required]
        [Display(Name = "Retirement Accounts")]
        public int RetirementAccounts { get; set; }

        [Required]
        [Display(Name = "Stock Bonds")]
        public int StockBonds { get; set; }

        [Required]
        public int Pension { get; set; }

        [Required]
        [Display(Name = "Business Interest")]
        public int BusinessInterest { get; set; }

        [Required]
        [Display(Name = "Money Owed To You")]
        public int MoneyOwedToYou { get; set; }

        [Required]
        [Display(Name = "Other Assets Or Money")]
        public int OtherAssetsOrMoney { get; set; }

        [Required]
        [Display(Name = "House Hold Size")]
        public int HouseHoldSize { get; set; }

        [Required]
        [Display(Name = "Monthly Income")]
        public int MonthlyIncome { get; set; }

        [StringLength(50), Required]
        [Display(Name = "Marital Status")]
        public string MaritalStatus { get; set; }

        [StringLength(50), Required]
        [Display(Name = "Full Name Spouse")]
        public string FullNameSpouse { get; set; }

        [Required]
        [Display(Name = "Have Children")]
        public bool HaveChildren { get; set; }

        [Required]
        [Display(Name = "Under Age Children")]
        public bool UnderAgeChildren { get; set; }

        [StringLength(50), Required]
        [Display(Name = "Minor Children Different Spouse")]
        public string MinorChildrenDifferentSpouse { get; set; }

        [Required]
        [Display(Name = "Currently Pregnant")]
        public bool CurrentlyPregnant { get; set; }

        [Required]
        [Display(Name = "Specific Bequest")]
        public bool SpecificBequest { get; set; }

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

        [Display(Name = "Disinherit Someone")]
        public bool DisinheritSomeone { get; set; }

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

        [Required]
        [Display(Name = "Request Power Of Attorney")]
        public bool RequestPowerOfAttorney { get; set; }

        [StringLength(50)]
        [Display(Name = "Primary Attorney")]
        public string PrimaryAttorney { get; set; }

        [StringLength(50)]
        [Display(Name = "Alternate Attorney")]
        public string AlternateAttorney { get; set; }

        [Required]
        [Display(Name = "Health Care Directive")]
        public bool HealthCareDirective { get; set; }

        [Required]
        [Display(Name = "Hydration Directive")]
        public bool HydrationDirective { get; set; }

        [Required]
        [Display(Name = "Nutrition Directive")]
        public bool NutritionDirective { get; set; }

        [Required]
        [Display(Name = "Artificial Ventilation")]
        public bool ArtificialVentilation { get; set; }

        [Required]
        [Display(Name = "Distress Medication")]
        public bool DistressMedication { get; set; }

        [Required]
        [Display(Name = "Is Completed")]
        public bool IsCompleted { get; set; }
    }
}
