using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WillClinic.Data;
using WillClinic.Models;
using WillClinic.Models.AccountViewModels;
using WillClinic.Models.IntakeFormViewModels;

namespace WillClinic.Controllers
{
    public class VeteranIntakeFormController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public VeteranIntakeFormController(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            ApplicationDbContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
                return NotFound();

            var veteranIntakeForm = await _context.VeteranIntakeForms
                .SingleOrDefaultAsync(m => m.VeteranApplicationUserId == id);
            if (veteranIntakeForm == null)
                return NotFound();

            return View(veteranIntakeForm);
        }

        [HttpGet]
        public IActionResult GoToStep(byte step = 0)
        {
            if (step == 1) return RedirectToAction(nameof(CreateStep1));
            if (step == 2) return RedirectToAction(nameof(CreateStep2));
            if (step == 3) return RedirectToAction(nameof(CreateStep3));
            if (step == 4) return RedirectToAction(nameof(CreateStep4));
            if (step == 5) return RedirectToAction(nameof(CreateStep5));
            if (step == 6) return RedirectToAction(nameof(CreateStep6));
            if (step == 7) return RedirectToAction(nameof(CreateStep7));
            if (step == 8) return RedirectToAction(nameof(CreateStep8));
            return RedirectToAction(nameof(CreateStep0));
        }

        [HttpGet]
        public IActionResult CreateStep0()
        {
            IntakeFormViewModel0 ifvm = new IntakeFormViewModel0();
            VeteranIntakeForm veteranIntakeForm = _context.VeteranIntakeForms.FirstOrDefault(form =>
                    form.VeteranApplicationUserId == _userManager.GetUserId(User) &&
                    form.IsCompleted == null
                );
            if (veteranIntakeForm != null)
            {
                ifvm.TermsAndConditions = veteranIntakeForm.TermsAndConditions;
                
                return View(ifvm);
            }

            return View(ifvm);
        }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateStep0(IntakeFormViewModel0 intakeFormViewModel)
        {
            if (ModelState.IsValid)
            {
                VeteranIntakeForm veteranIntakeForm = new VeteranIntakeForm();
                veteranIntakeForm.CurrentStep = 1;
                veteranIntakeForm.TimeStamp = DateTime.Now;

                veteranIntakeForm.VeteranApplicationUserId = _userManager.GetUserId(User);
                veteranIntakeForm.TermsAndConditions = true;

                await _context.AddAsync(veteranIntakeForm);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(GoToStep), new { step = veteranIntakeForm.CurrentStep });
            }
            return View(nameof(CreateStep0));
        }

        [HttpGet]
        public IActionResult CreateStep1()
        {
            IntakeFormViewModel1 ifvm = new IntakeFormViewModel1();
            VeteranIntakeForm veteranIntakeForm = _context.VeteranIntakeForms.FirstOrDefault(form =>
                    form.VeteranApplicationUserId == _userManager.GetUserId(User) &&
                    form.IsCompleted == null
                );
            if (veteranIntakeForm != null)
            {
                ifvm.FullLegalName = veteranIntakeForm.FullLegalName;
                ifvm.Address = veteranIntakeForm.Address;
                ifvm.PhoneNumber = veteranIntakeForm.PhoneNumber;
                
                return View(ifvm);
            }

            return View(ifvm);
        }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateStep1([Bind("FullLegalName,Address,PhoneNumber")] IntakeFormViewModel1 intakeFormViewModel)
        {
            if (ModelState.IsValid)
            {
                VeteranIntakeForm currentForm = _context.VeteranIntakeForms.FirstOrDefault(form =>
                    form.VeteranApplicationUserId == _userManager.GetUserId(User) &&
                    form.IsCompleted == null
                );

                currentForm.CurrentStep = 2;
                currentForm.TimeStamp = DateTime.Now;

                currentForm.FullLegalName = intakeFormViewModel.FullLegalName;
                currentForm.Address = intakeFormViewModel.Address;
                currentForm.PhoneNumber = intakeFormViewModel.PhoneNumber;

                _context.VeteranIntakeForms.Update(currentForm);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(GoToStep), new { step = currentForm.CurrentStep });
            }
            return View(nameof(CreateStep1));
        }


        [HttpGet]
        public IActionResult CreateStep2()
        {
            IntakeFormViewModel2 ifvm = new IntakeFormViewModel2();
            VeteranIntakeForm veteranIntakeForm = _context.VeteranIntakeForms.FirstOrDefault(form =>
                    form.VeteranApplicationUserId == _userManager.GetUserId(User) &&
                    form.IsCompleted == null
                );
            if (veteranIntakeForm != null)
            {
                ifvm.ProofOfService = veteranIntakeForm.ProofOfService;
                ifvm.ResidentStatus = veteranIntakeForm.ResidentStatus;
                ifvm.VeteranStatus = veteranIntakeForm.VeteranStatus;
                ifvm.NetWorth = veteranIntakeForm.NetWorth;
                
                return View(ifvm);
            }

            return View(ifvm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateStep2(IntakeFormViewModel2 intakeFormViewModel)
        {
            if (ModelState.IsValid)
            {
                VeteranIntakeForm currentForm = _context.VeteranIntakeForms.FirstOrDefault(form =>
                    form.VeteranApplicationUserId == _userManager.GetUserId(User) &&
                    form.IsCompleted == null
                );

                currentForm.CurrentStep = 3;
                currentForm.TimeStamp = DateTime.Now;

                currentForm.VeteranStatus = intakeFormViewModel.VeteranStatus;
                currentForm.ProofOfService = intakeFormViewModel.ProofOfService;
                currentForm.ResidentStatus = intakeFormViewModel.ResidentStatus;
                currentForm.NetWorth = intakeFormViewModel.NetWorth;

                _context.VeteranIntakeForms.Update(currentForm);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(GoToStep), new { step = currentForm.CurrentStep });
            }
            return View(nameof(CreateStep2));
        }

        [HttpGet]
        public IActionResult CreateStep3()
        {        
            IntakeFormViewModel3 ifvm = new IntakeFormViewModel3();
            VeteranIntakeForm veteranIntakeForm = _context.VeteranIntakeForms.FirstOrDefault(form =>
                    form.VeteranApplicationUserId == _userManager.GetUserId(User) &&
                    form.IsCompleted == null
                );
            if (veteranIntakeForm != null)
            {
                ifvm.MonthlyIncome = veteranIntakeForm.MonthlyIncome;
                ifvm.BankAccountAssets = veteranIntakeForm.BankAccountAssets;
                ifvm.RealEstateAssets = veteranIntakeForm.RealEstateAssets;
                ifvm.LifeInsuranceCashValue = veteranIntakeForm.LifeInsuranceCashValue;
                ifvm.RetirementAccounts = veteranIntakeForm.RetirementAccounts;
                ifvm.StockBonds = veteranIntakeForm.StockBonds;
                ifvm.Pension = veteranIntakeForm.Pension;
                ifvm.BusinessInterest = veteranIntakeForm.BusinessInterest;
                ifvm.MoneyOwedToYou = veteranIntakeForm.MoneyOwedToYou;
                ifvm.OtherAssetsOrMoney = veteranIntakeForm.OtherAssetsOrMoney;

                return View(ifvm);
            }

            return View(ifvm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateStep3([Bind("MonthlyIncome,BankAccountAssets,RealEstateAssets,LifeInsuranceCashValue,RetirementAccounts,StockBonds,Pension,BusinessInterest,MoneyOwedToYou,OtherAssetsOrMoney")]IntakeFormViewModel3 intakeFormViewModel)
        {
            if (ModelState.IsValid)
            {
                VeteranIntakeForm currentForm = _context.VeteranIntakeForms.FirstOrDefault(form =>
                    form.VeteranApplicationUserId == _userManager.GetUserId(User) &&
                    form.IsCompleted == null
                );

                currentForm.CurrentStep = 4;
                currentForm.TimeStamp = DateTime.Now;

                currentForm.MonthlyIncome = intakeFormViewModel.MonthlyIncome;
                currentForm.BankAccountAssets = intakeFormViewModel.BankAccountAssets;
                currentForm.RealEstateAssets = intakeFormViewModel.RealEstateAssets;
                currentForm.LifeInsuranceCashValue = intakeFormViewModel.LifeInsuranceCashValue;
                currentForm.RetirementAccounts = intakeFormViewModel.RetirementAccounts;
                currentForm.StockBonds = intakeFormViewModel.StockBonds;
                currentForm.Pension = intakeFormViewModel.Pension;
                currentForm.BusinessInterest = intakeFormViewModel.BusinessInterest;
                currentForm.MoneyOwedToYou = intakeFormViewModel.MoneyOwedToYou;
                currentForm.OtherAssetsOrMoney = intakeFormViewModel.OtherAssetsOrMoney;

                _context.VeteranIntakeForms.Update(currentForm);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(GoToStep), new { step = currentForm.CurrentStep });
            }
            return View(nameof(CreateStep3));
        }

        [HttpGet]
        public IActionResult CreateStep4()
        {
            IntakeFormViewModel4 ifvm = new IntakeFormViewModel4();
            VeteranIntakeForm veteranIntakeForm = _context.VeteranIntakeForms.FirstOrDefault(form =>
                    form.VeteranApplicationUserId == _userManager.GetUserId(User) &&
                    form.IsCompleted == null
                );
            if (veteranIntakeForm != null)
            {
                ifvm.HouseHoldSize = veteranIntakeForm.HouseHoldSize;
                ifvm.MaritalStatus = veteranIntakeForm.MaritalStatus;
                ifvm.FullNameSpouse = veteranIntakeForm.FullNameSpouse;
                ifvm.HaveChildren = veteranIntakeForm.HaveChildren;
                ifvm.UnderAgeChildren = veteranIntakeForm.UnderAgeChildren;
                ifvm.MinorChildrenDifferentSpouse = veteranIntakeForm.MinorChildrenDifferentSpouse;
                ifvm.CurrentlyPregnant = veteranIntakeForm.CurrentlyPregnant;
                ifvm.SpecificBequest = veteranIntakeForm.SpecificBequest;
                ifvm.BequestInfromation = veteranIntakeForm.BequestInfromation;
                ifvm.InheritEstate = veteranIntakeForm.InheritEstate;
                ifvm.InheritEstateSpecific = veteranIntakeForm.InheritEstateSpecific;
                ifvm.RemainderBeneficiary = veteranIntakeForm.RemainderBeneficiary;
                ifvm.RemainderBeneficiarySpecific = veteranIntakeForm.RemainderBeneficiarySpecific;
                ifvm.DisinheritSomeone = veteranIntakeForm.DisinheritSomeone;
                ifvm.DisinheretDescription = veteranIntakeForm.DisinheritDescription;
                ifvm.PrimaryGuardian = veteranIntakeForm.PrimaryGuardian;
                ifvm.AlternateGuardian = veteranIntakeForm.AlternateGuardian;
                ifvm.PersonalRepresentative = veteranIntakeForm.PersonalRepresentative;
                ifvm.AlternateRepresentative = veteranIntakeForm.AlternateRepresentative;

                return View(ifvm);
            }

            return View(ifvm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateStep4(IntakeFormViewModel4 intakeFormViewModel)

        {
            if (ModelState.IsValid)
            {
                VeteranIntakeForm currentForm = _context.VeteranIntakeForms.FirstOrDefault(form =>
                    form.VeteranApplicationUserId == _userManager.GetUserId(User) &&
                    form.IsCompleted == null
                );

                currentForm.CurrentStep = 5;
                currentForm.TimeStamp = DateTime.Now;

                currentForm.HouseHoldSize = intakeFormViewModel.HouseHoldSize;
                currentForm.MaritalStatus = intakeFormViewModel.MaritalStatus;
                currentForm.FullNameSpouse = intakeFormViewModel.FullNameSpouse;
                currentForm.HaveChildren = intakeFormViewModel.HaveChildren;
                currentForm.UnderAgeChildren = intakeFormViewModel.UnderAgeChildren;
                currentForm.MinorChildrenDifferentSpouse = intakeFormViewModel.MinorChildrenDifferentSpouse;
                currentForm.CurrentlyPregnant = intakeFormViewModel.CurrentlyPregnant;
                currentForm.SpecificBequest = intakeFormViewModel.SpecificBequest;
                currentForm.BequestInfromation = intakeFormViewModel.BequestInfromation;
                currentForm.InheritEstate = intakeFormViewModel.InheritEstate;
                currentForm.InheritEstateSpecific = intakeFormViewModel.InheritEstateSpecific;
                currentForm.RemainderBeneficiary = intakeFormViewModel.RemainderBeneficiary;
                currentForm.RemainderBeneficiarySpecific = intakeFormViewModel.RemainderBeneficiarySpecific;
                currentForm.DisinheritSomeone = intakeFormViewModel.DisinheritSomeone;
                currentForm.DisinheritDescription = intakeFormViewModel.DisinheretDescription;
                currentForm.PrimaryGuardian = intakeFormViewModel.PrimaryGuardian;
                currentForm.AlternateGuardian = intakeFormViewModel.AlternateGuardian;
                currentForm.PersonalRepresentative = intakeFormViewModel.PersonalRepresentative;
                currentForm.AlternateRepresentative = intakeFormViewModel.AlternateRepresentative;
                _context.VeteranIntakeForms.Update(currentForm);

                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(GoToStep), new { step = currentForm.CurrentStep });
            }
            return View(nameof(CreateStep4));
        }

        [HttpGet]
        public IActionResult CreateStep5()
        {
            IntakeFormViewModel5 ifvm = new IntakeFormViewModel5();
            VeteranIntakeForm veteranIntakeForm = _context.VeteranIntakeForms.FirstOrDefault(form =>
                    form.VeteranApplicationUserId == _userManager.GetUserId(User) &&
                    form.IsCompleted == null
                );
            if (veteranIntakeForm != null)
            {
                ifvm.RequestPowerOfAttorney = veteranIntakeForm.RequestPowerOfAttorney;
                ifvm.PrimaryAttorney = veteranIntakeForm.PrimaryAttorney;
                ifvm.AlternateAttorney = veteranIntakeForm.AlternateAttorney;

                return View(ifvm);
            }

            return View(ifvm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateStep5(IntakeFormViewModel5 intakeFormViewModel)
        {
            if (ModelState.IsValid)
            {
                VeteranIntakeForm currentForm = _context.VeteranIntakeForms.FirstOrDefault(form =>
                    form.VeteranApplicationUserId == _userManager.GetUserId(User) &&
                    form.IsCompleted == null
                );

                currentForm.CurrentStep = 6;
                currentForm.TimeStamp = DateTime.Now;

                currentForm.RequestPowerOfAttorney = intakeFormViewModel.RequestPowerOfAttorney;
                currentForm.PrimaryAttorney = intakeFormViewModel.PrimaryAttorney;
                currentForm.AlternateAttorney = intakeFormViewModel.AlternateAttorney;

                _context.VeteranIntakeForms.Update(currentForm);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(GoToStep), new { step = currentForm.CurrentStep });
            }
            return View(nameof(CreateStep5));
        }

        [HttpGet]
        public IActionResult CreateStep6()
        {
            IntakeFormViewModel6 ifvm = new IntakeFormViewModel6();
            VeteranIntakeForm veteranIntakeForm = _context.VeteranIntakeForms.FirstOrDefault(form =>
                    form.VeteranApplicationUserId == _userManager.GetUserId(User) &&
                    form.IsCompleted == null
                );
            if (veteranIntakeForm != null)
            {
                ifvm.HealthCareDirective = veteranIntakeForm.HealthCareDirective;
                ifvm.HydrationDirective = veteranIntakeForm.HydrationDirective;
                ifvm.NutritionDirective = veteranIntakeForm.NutritionDirective;
                ifvm.ArtificialVentilation = veteranIntakeForm.ArtificialVentilation;
                ifvm.DistressMedication = veteranIntakeForm.DistressMedication;

                return View(ifvm);
            }

            return View(ifvm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateStep6(IntakeFormViewModel6 intakeFormViewModel)
        {
            if (ModelState.IsValid)
            {
                VeteranIntakeForm currentForm = _context.VeteranIntakeForms.FirstOrDefault(form =>
                    form.VeteranApplicationUserId == _userManager.GetUserId(User) &&
                    form.IsCompleted == null
                );

                currentForm.CurrentStep = 7;
                currentForm.TimeStamp = DateTime.Now;

                currentForm.HealthCareDirective = intakeFormViewModel.HealthCareDirective;
                currentForm.HydrationDirective = intakeFormViewModel.HydrationDirective;
                currentForm.NutritionDirective = intakeFormViewModel.NutritionDirective;
                currentForm.ArtificialVentilation = intakeFormViewModel.ArtificialVentilation;
                currentForm.DistressMedication = intakeFormViewModel.DistressMedication;

                _context.VeteranIntakeForms.Update(currentForm);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(GoToStep), new { step = currentForm.CurrentStep });
            }
            return View(nameof(CreateStep6));
        }

        [HttpGet]
        public IActionResult CreateStep7()
        {
            IntakeFormViewModel7 ifvm = new IntakeFormViewModel7();
            VeteranIntakeForm veteranIntakeForm = _context.VeteranIntakeForms.FirstOrDefault(form =>
                    form.VeteranApplicationUserId == _userManager.GetUserId(User) &&
                    form.IsCompleted == null
                );
            if (veteranIntakeForm != null)
            {
                ifvm.HealthPOA = veteranIntakeForm.HealthPOA;
                ifvm.PrimaryHealthAttorney = veteranIntakeForm.PrimaryHealthAttorney;
                ifvm.SecondaryHealthAttorney = veteranIntakeForm.SecondaryHealthAttorney;

                return View(ifvm);
            }

            return View(ifvm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateStep7(IntakeFormViewModel7 intakeFormViewModel)
        {
            if (ModelState.IsValid)
            {
                VeteranIntakeForm currentForm = _context.VeteranIntakeForms.FirstOrDefault(form =>
                    form.VeteranApplicationUserId == _userManager.GetUserId(User) &&
                    form.IsCompleted == null
                );

                currentForm.CurrentStep = 8;
                currentForm.TimeStamp = DateTime.Now;

                currentForm.HealthPOA = intakeFormViewModel.HealthPOA;
                currentForm.PrimaryHealthAttorney = intakeFormViewModel.PrimaryHealthAttorney;
                currentForm.SecondaryHealthAttorney = intakeFormViewModel.SecondaryHealthAttorney;

                _context.VeteranIntakeForms.Update(currentForm);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(GoToStep), new { step = currentForm.CurrentStep });
            }
            return View(nameof(CreateStep7));
        }

        [HttpGet]
        public IActionResult CreateStep8()
        {
            // The whole form filled in ready for review
            VeteranIntakeForm formToReview = _context.VeteranIntakeForms.FirstOrDefault(form =>
                    form.VeteranApplicationUserId == _userManager.GetUserId(User) && 
                    form.IsCompleted == null);

            return View(formToReview);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateStep8(bool IsCompleted)
        {
            if (IsCompleted == true)
            {
                VeteranIntakeForm currentForm = _context.VeteranIntakeForms.FirstOrDefault(form =>
                    form.VeteranApplicationUserId == _userManager.GetUserId(User) &&
                    form.IsCompleted == null
                );

                currentForm.TimeStamp = DateTime.Now;
                currentForm.IsCompleted = IsCompleted;

                _context.VeteranIntakeForms.Update(currentForm);
                await _context.SaveChangesAsync();

                return RedirectToAction("Index", "Veteran");
            }
            return View(nameof(CreateStep8));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            if (id == 0)
                return RedirectToAction("Index", "Veteran");
            
            var veteranIntakeForm = await _context.VeteranIntakeForms.SingleOrDefaultAsync(m => m.ID == id);

            if (veteranIntakeForm == null)
                return RedirectToAction("Index", "Veteran");

            veteranIntakeForm.IsCompleted = null;

            _context.VeteranIntakeForms.Update(veteranIntakeForm);
            await _context.SaveChangesAsync();

            return RedirectToAction("GoToStep", new { step = 1 });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("ID,VeteranApplicationUserId,IsNotarized,TimeStamp,TermsAndConditions,FullLegalName,Address,PhoneNumber,VeteranStatus,ProofOfService,ResidentStatus,NetWorth,BankAccountAssets,RealEstateAssets,LifeInsuranceCashValue,RetirementAccounts,StockBonds,Pension,BusinessInterest,MoneyOwedToYou,OtherAssetsOrMoney,HouseHoldSize,MonthlyIncome,MaritalStatus,FullNameSpouse,HaveChildren,UnderAgeChildren,MinorChildrenDifferentSpouse,CurrentlyPregnant,SpecificBequest,BequestInfromation,InheritEstate,InheritEstateSpecific,RemainderBeneficiary,RemainderBeneficiarySpecific,DisinheritSomeone,DisinherentDescription,PrimaryGuardian,AlternateGuardian,PersonalRepresentative,AlternateRepresentative,RequestPowerOfAttorney,PrimaryAttorney,AlternateAttorney,HealthCareDirective,HydrationDirective,NutritionDirective,ArtificialVentilation,DistressMedication")] VeteranIntakeForm veteranIntakeForm)
        {
            if (id != veteranIntakeForm.VeteranApplicationUserId)
                return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(veteranIntakeForm);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VeteranIntakeFormExists(veteranIntakeForm.VeteranApplicationUserId))
                        return NotFound();
                    else
                        throw;
                }
                return RedirectToAction(nameof(VeteranController.Index));
            }
            return View(veteranIntakeForm);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
                return NotFound();

            var veteranIntakeForm = await _context.VeteranIntakeForms
                .SingleOrDefaultAsync(m => m.ID == int.Parse(id));

            if (veteranIntakeForm == null)
                return NotFound();

            return View(veteranIntakeForm);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var veteranIntakeForm = await _context.VeteranIntakeForms.SingleOrDefaultAsync(m => m.ID == id);
            _context.VeteranIntakeForms.Remove(veteranIntakeForm);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "Veteran");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SaveAndExit(VeteranIntakeForm saveForm)
        {

            _context.VeteranIntakeForms.Update(saveForm);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index", "Veteran");
        }

        private bool VeteranIntakeFormExists(string id)
        {
            return _context.VeteranIntakeForms.Any(e => e.VeteranApplicationUserId == id);
        }
    }
}
