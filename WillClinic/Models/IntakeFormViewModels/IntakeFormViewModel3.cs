using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WillClinic.Models.IntakeFormViewModels
{
    public class IntakeFormViewModel3
    {
        [Required]
        [Display(Name = "Monthly Income")]
        public int MonthlyIncome { get; set; }

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
    }
}
