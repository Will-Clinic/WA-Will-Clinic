using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WillClinic.Models
{
    public class VeteranIntake
    {
        public int ID { get; set; }

        public string VeteranModelApplicationUserId { get; set; }

        public Veteran Author { get; set; }

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
        public int BankAccountAssests { get; set; }

        [Required]
        public int RealEstateAssest { get; set; }

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
        public int OtherAssestsOrMoney { get; set; }

        [Required]
        public int HouseHoldSiza { get; set; }

        [Required]
        public int MonthlyIncome { get; set; }

        [StringLength(50), Required]
        public MaritalStatus MaritalStatus { get; set; }

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

        //[StringLength(50), Required]
        //public string ChildName { get; set; }

        //[StringLength(50), Required]
        //public DateTime DateOfBirth { get; }

        //[StringLength(50), Required]
        //public string BiologicalAdoptive { get; }

        //[StringLength(50), Required]
        //public bool AdditionalChildren { get; }

        [Required]
        public bool SpecificBequest { get; set; }

        [StringLength(500), Required]
        public string BequestInfromation { get; set; }

        [Required]
        public InheritEstate InheritEstate { get; set; }

        [StringLength(1000), Required]
        public string InheritEstateSpecific { get; set; }

        [Required]
        public RemainderBeneficiary RemainderBeneficiary { get; set; }

        [StringLength(1000), Required]
        public string RemainderBeneficiarySpecific { get; set; }

        [Required]
        public bool DisinheritSomeone { get; set; }

        [StringLength(75), Required]
        public string DisinherentDescription { get; set; }

        [StringLength(50), Required]
        public string PrimaryGuardian { get; set; }

        [StringLength(50), Required]
        public string AlternateGuardian { get; set; }

        [StringLength(50), Required]
        public string PersonalRepresentative { get; set; }

        [StringLength(50), Required]
        public string AlternateRepresentative { get; set; }

        [Required]
        public bool PowerOfAttorney { get; set; }

        [StringLength(50), Required]
        public string PrimaryAttorney { get; set; }

        [StringLength(50), Required]
        public string AlternateAttorney { get; set; }

        [Required]
        public bool HealthCareDirective { get; set; }
    }
}



