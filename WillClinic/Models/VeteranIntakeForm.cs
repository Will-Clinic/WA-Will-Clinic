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
        public bool IsNotarized { get; set; }
        public byte CurrentStep { get; set; }
        public DateTime TimeStamp { get; set; }
        public Veteran Veteran { get; set; }
        public bool TermsAndConditions { get; set; }
        public string FullLegalName { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public bool VeteranStatus { get; set; }
        public bool ProofOfService { get; set; }
        public bool ResidentStatus { get; set; }
        public bool NetWorth { get; set; }
        public int BankAccountAssets { get; set; }
        public int RealEstateAssets { get; set; }
        public int LifeInsuranceCashValue { get; set; }
        public int RetirementAccounts { get; set; }
        public int StockBonds { get; set; }
        public int Pension { get; set; }
        public int BusinessInterest { get; set; }
        public int MoneyOwedToYou { get; set; }
        public int OtherAssetsOrMoney { get; set; }
        public int HouseHoldSize { get; set; }
        public int MonthlyIncome { get; set; }
        public string MaritalStatus { get; set; }
        public string FullNameSpouse { get; set; }
        public bool HaveChildren { get; set; }
        public bool UnderAgeChildren { get; set; }
        public string MinorChildrenDifferentSpouse { get; set; }
        public bool CurrentlyPregnant { get; set; }
        public bool SpecificBequest { get; set; }
        public string BequestInfromation { get; set; }
        public InheritEstate InheritEstate { get; set; }
        public string InheritEstateSpecific { get; set; }
        public RemainderBeneficiary RemainderBeneficiary { get; set; }
        public string RemainderBeneficiarySpecific { get; set; }
        public bool DisinheritSomeone { get; set; }
        public string DisinheritDescription { get; set; }
        public string PrimaryGuardian { get; set; }
        public string AlternateGuardian { get; set; }
        public string PersonalRepresentative { get; set; }
        public string AlternateRepresentative { get; set; }
        public bool RequestPowerOfAttorney { get; set; }
        public string PrimaryAttorney { get; set; }
        public string AlternateAttorney { get; set; }
        public bool HealthCareDirective { get; set; }
        public bool HydrationDirective { get; set; }
        public bool NutritionDirective { get; set; }
        public bool ArtificialVentilation { get; set; }
        public bool DistressMedication { get; set; }
        public bool IsCompleted { get; set; }
    }
}




