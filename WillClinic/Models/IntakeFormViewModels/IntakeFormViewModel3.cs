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
        [DataType(DataType.Currency)]
        public int MonthlyIncome { get; set; }

        [Required]
        [Display(Name = "Bank Account Assets")]
        [DataType(DataType.Currency)]
        public int BankAccountAssets { get; set; }

        [Required]
        [Display(Name = "Real Estate Assets")]
        [DataType(DataType.Currency)]
        public int RealEstateAssets { get; set; }

        [Required]
        [Display(Name = "Life Insurance Cash Value")]
        [DataType(DataType.Currency)]
        public int LifeInsuranceCashValue { get; set; }

        [Required]
        [Display(Name = "Retirement Accounts")]
        [DataType(DataType.Currency)]
        public int RetirementAccounts { get; set; }

        [Required]
        [Display(Name = "Stock Bonds")]
        [DataType(DataType.Currency)]
        public int StockBonds { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        public int Pension { get; set; }

        [Required]
        [Display(Name = "Business Interest")]
        [DataType(DataType.Currency)]
        public int BusinessInterest { get; set; }

        [Required]
        [Display(Name = "Money Owed To You")]
        [DataType(DataType.Currency)]
        public int MoneyOwedToYou { get; set; }

        [Required]
        [Display(Name = "Other Assets Or Money")]
        [DataType(DataType.Currency)]
        public int OtherAssetsOrMoney { get; set; }

        [Display(Name = "Save & Exit")]
        public string Exit { get; set; }
    }
}
