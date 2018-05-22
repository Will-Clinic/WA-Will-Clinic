using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WillClinic.Models.VeteranModels
{
    public class VeteranNetWorth
    {
        public int Id { get; set; }

        public int MonthlyIncome { get; set; }
        public int BankAccountAssets { get; set; }
        public int RealEstateAssets { get; set; }
        public int LifeInsuranceCashValue { get; set; }
        public int RetirementAccounts { get; set; }
        public int StockBonds { get; set; }
        public int Pension { get; set; }
        public int BusinessInterest { get; set; }
        public int MoneyOwedToYou { get; set; }
        public int OtherAssetsOrMoney { get; set; }
    }
}
