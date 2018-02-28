using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WillClinic.Models
{
    public class VeteranIntakeForm
    {
        public int ID { get; set; }

        public string VeteranApplicationUserId { get; set; }

        [Required]
        public bool IsNotarized { get; set; }

        [Required]
        public byte CurrentStep { get; set; }

        [Required]
        public DateTime TimeStamp { get; set; }

        public Veteran Veteran { get; set; }

        [Required]
        public bool TermsAndConditions { get; set; }

        [StringLength(50), Required]
        public string FullLegalName { get; set; }

        [StringLength(50), Required]
        public string Address { get; set; }

        [Required]
        public int PhoneNumber { get; set; }

        [Required]
        public bool VeteranStatus { get; set; }

        [Required]
        public bool ProofOfService { get; set; }

        [Required]
        public bool ResidentStatus { get; set; }

        [Required]
        public bool NetWorth { get; set; }

        [Required]
        public int BankAccountAssets { get; set; }

        [Required]
        public int RealEstateAssets { get; set; }

        [Required]
        public int LifeInsuranceCashValue { get; set; }

        [Required]
        public int RetirementAccounts { get; set; }

        [Required]
        public int StockBonds { get; set; }

        [Required]
        public int Pension { get; set; }

        [Required]
        public int BusinessInterest { get; set; }

        [Required]
        public int MoneyOwedToYou { get; set; }

        [Required]
        public int OtherAssetsOrMoney { get; set; }

        [Required]
        public int HouseHoldSize { get; set; }

        [Required]
        public int MonthlyIncome { get; set; }

        [StringLength(50), Required]
        public string MaritalStatus { get; set; }

        [StringLength(50), Required]
        public string FullNameSpouse { get; set; }

        [Required]
        public bool HaveChildren { get; set; }

        [Required]
        public bool UnderAgeChildren { get; set; }

        [StringLength(50), Required]
        public string MinorChildrenDifferentSpouse { get; set; }

        [Required]
        public bool CurrentlyPregnant { get; set; }
        
        [Required]
        public bool SpecificBequest { get; set; }

        [StringLength(500)]
        public string BequestInfromation { get; set; }
       
        public InheritEstate InheritEstate { get; set; }

        [StringLength(1000)]
        public string InheritEstateSpecific { get; set; }
        
        public RemainderBeneficiary RemainderBeneficiary { get; set; }

        [StringLength(1000)]
        public string RemainderBeneficiarySpecific { get; set; }
        
        public bool DisinheritSomeone { get; set; }

        [StringLength(75)]
        public string DisinherentDescription { get; set; }

        [StringLength(50)]
        public string PrimaryGuardian { get; set; }

        [StringLength(50)]
        public string AlternateGuardian { get; set; }

        [StringLength(50)]
        public string PersonalRepresentative { get; set; }

        [StringLength(50)]
        public string AlternateRepresentative { get; set; }

        [Required]
        public bool RequestPowerOfAttorney { get; set; }

        [StringLength(50)]
        public string PrimaryAttorney { get; set; }

        [StringLength(50)]
        public string AlternateAttorney { get; set; }

        [Required]
        public bool HealthCareDirective { get; set; }

        [Required]
        public bool HydrationDirective { get; set; }

        [Required]
        public bool NutritionDirective { get; set; }

        [Required]
        public bool ArtificialVentilation { get; set; }

        [Required]
        public bool DistressMedication { get; set; }

    }
}




