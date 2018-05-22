using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WillClinic.Models;
using WillClinic.Models.Services;

namespace WillClinic.Pages
{
    public class NetWorthModel : PageModel
    {
        public int Id { get; set; }
        public Veteran Veteran { get; set; }
        internal IVeteranService VeteranService { get; set; }

        [BindProperty]
        public int MonthlyIncome { get; set; }

        [BindProperty]
        public int BankAccountAssets { get; set; }

        [BindProperty]
        public int RealEstateAssets { get; set; }

        [BindProperty]
        public int LifeInsuranceCashValue { get; set; }

        [BindProperty]
        public int RetirementAccounts { get; set; }

        [BindProperty]
        public int StockBonds { get; set; }

        [BindProperty]
        public int Pension { get; set; }

        [BindProperty]
        public int BusinessInterest { get; set; }

        [BindProperty]
        public int MoneyOwedToYou { get; set; }

        [BindProperty]
        public int OtherAssestsOrMoney { get; set; }

        [TempData]
        public string Message { get; set; }

        public NetWorthModel(IVeteranService vs)
        {
            VeteranService = vs;
        }

        public async Task<IActionResult> OnGet(int id)
        {
            Veteran = await VeteranService.FindAsync(id);

            if (Veteran == null)
            {
                return RedirectToPage("Index");
            }

            return Page();
        }

        public async Task<IActionResult> OnPost(int id)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            Veteran veteran = await VeteranService.FindAsync(id);
            veteran.VeteranNetWorth.MonthlyIncome = Veteran.VeteranNetWorth.MonthlyIncome;
            veteran.VeteranNetWorth.BankAccountAssets = Veteran.VeteranNetWorth.BankAccountAssets;
            veteran.VeteranNetWorth.RealEstateAssets = Veteran.VeteranNetWorth.RealEstateAssets;
            veteran.VeteranNetWorth.LifeInsuranceCashValue = Veteran.VeteranNetWorth.LifeInsuranceCashValue;
            veteran.VeteranNetWorth.RetirementAccounts = Veteran.VeteranNetWorth.RetirementAccounts;
            veteran.VeteranNetWorth.StockBonds = Veteran.VeteranNetWorth.StockBonds;
            veteran.VeteranNetWorth.Pension = Veteran.VeteranNetWorth.Pension;
            veteran.VeteranNetWorth.BusinessInterest = Veteran.VeteranNetWorth.BusinessInterest;
            veteran.VeteranNetWorth.MoneyOwedToYou = Veteran.VeteranNetWorth.MoneyOwedToYou;
            veteran.VeteranNetWorth.OtherAssetsOrMoney = Veteran.VeteranNetWorth.OtherAssetsOrMoney;

            try
            {
                await VeteranService.SaveAsync(veteran);
            }
            catch (DbUpdateConcurrencyException)
            {
                Message = "Profile not found";
            }

            return RedirectToPage("Index");
        }
    }
}