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

        /// <summary>
        /// Handles the detail view of a VeteranIntakeForm
        /// </summary>
        /// <param name="id">Veteran id</param>
        /// <returns>View of VeteranIntakeForm</returns>
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

        /// <summary>
        /// Handles the changing of steps while a Veteran is going through
        /// the intake form.
        /// </summary>
        /// <param name="step">A byte type of the next page the veteran is going to</param>
        /// <returns>Redirects to the correct intake form page</returns>
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

        // USER AGREEMENT
        /// <summary>
        /// Checks to see if the veteran has form data currently available, if
        /// the veteran has data, it will repopulate that data, if not then just
        /// a blank form is displayed for step 0
        /// </summary>
        /// <returns>IntakeFormViewModel0</returns>
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
        /// <summary>
        /// Handles posting of the information input by the veteran
        /// </summary>
        /// <param name="intakeFormViewModel">IntakeFormViewModel0</param>
        /// <returns>View of create step 0</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateStep0(IntakeFormViewModel0 intakeFormViewModel)
        {
            //if (ModelState.IsValid)
            //{
                VeteranIntakeForm veteranIntakeForm = new VeteranIntakeForm();
                veteranIntakeForm.CurrentStep = 1;
                veteranIntakeForm.TimeStamp = DateTime.Now;

                veteranIntakeForm.VeteranApplicationUserId = _userManager.GetUserId(User);
                veteranIntakeForm.TermsAndConditions = true;

                await _context.AddAsync(veteranIntakeForm);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(GoToStep), new { step = veteranIntakeForm.CurrentStep });
            //}
            return View(nameof(CreateStep0));
        }
        // PERSONAL INFORMATION
        /// <summary>
        /// Checks to see if the veteran has form data currently available, if
        /// the veteran has data, it will repopulate that data, if not then just
        /// a blank form is displayed for step 1 
        /// </summary>
        /// <returns>IntakeFormViewModel1</returns>
        [HttpGet]
        public async Task<IActionResult> CreateStep1()
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

                veteranIntakeForm.CurrentStep = 1;
                _context.Update(veteranIntakeForm);
                await _context.SaveChangesAsync();

                return View(ifvm);
            }

            return View(ifvm);
        }

        /// <summary>
        /// Handles posting of the information input by the veteran
        /// </summary>
        /// <param name="intakeFormViewModel">IntakeFormViewModel1</param>
        /// <returns>View of create step 1</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateStep1([Bind("FullLegalName,Address,PhoneNumber,Exit")] IntakeFormViewModel1 intakeFormViewModel)
        {
            //if (ModelState.IsValid)
            //{
            VeteranIntakeForm currentForm = _context.VeteranIntakeForms.FirstOrDefault(form =>
                form.VeteranApplicationUserId == _userManager.GetUserId(User) &&
                form.IsCompleted == null
            );

            // currentForm.CurrentStep = 2;
            currentForm.TimeStamp = DateTime.Now;

            currentForm.FullLegalName = intakeFormViewModel.FullLegalName;
            currentForm.Address = intakeFormViewModel.Address;
            currentForm.PhoneNumber = intakeFormViewModel.PhoneNumber;

            if (intakeFormViewModel.Exit != null)
            {
                _context.VeteranIntakeForms.Update(currentForm);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "Veteran");
            }
            currentForm.CurrentStep = 2;
            _context.VeteranIntakeForms.Update(currentForm);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(GoToStep), new { step = currentForm.CurrentStep });
            //}
            //return View(nameof(CreateStep1));
        }

        // VETERAN STATUS
        /// <summary>
        /// Checks to see if the veteran has form data currently available, if
        /// the veteran has data, it will repopulate that data, if not then just
        /// a blank form is displayed for step 2 
        /// </summary>
        /// <returns>IntakeFormViewModel2</returns>
        [HttpGet]
        public async Task<IActionResult> CreateStep2()
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

                veteranIntakeForm.CurrentStep = 2;
                _context.Update(veteranIntakeForm);
                await _context.SaveChangesAsync();

                return View(ifvm);
            }

            return View(ifvm);
        }

        /// <summary>
        /// Handles posting of the information input by the veteran
        /// </summary>
        /// <param name="intakeFormViewModel">IntakeFormViewModel2</param>
        /// <returns>View of create step 2</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateStep2(
            [Bind("VeteranStatus,ProofOfService,ResidentStatus,NetWorth,Exit")] IntakeFormViewModel2 intakeFormViewModel)
        {
            //if (ModelState.IsValid)
            //{
                VeteranIntakeForm currentForm = _context.VeteranIntakeForms.FirstOrDefault(form =>
                    form.VeteranApplicationUserId == _userManager.GetUserId(User) &&
                    form.IsCompleted == null
                );

                //currentForm.CurrentStep = 3;
                currentForm.TimeStamp = DateTime.Now;

                currentForm.VeteranStatus = intakeFormViewModel.VeteranStatus;
                currentForm.ProofOfService = intakeFormViewModel.ProofOfService;
                currentForm.ResidentStatus = intakeFormViewModel.ResidentStatus;
                currentForm.NetWorth = intakeFormViewModel.NetWorth;

                if (intakeFormViewModel.Exit != null)
                {
                    _context.VeteranIntakeForms.Update(currentForm);
                    await _context.SaveChangesAsync();
                    return RedirectToAction("Index", "Veteran");
                }

                currentForm.CurrentStep = 3;
                _context.VeteranIntakeForms.Update(currentForm);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(GoToStep), new { step = currentForm.CurrentStep });
           // }
           // return View(nameof(CreateStep2));
        }

        // FINANCES
        /// <summary>
        /// Checks to see if the veteran has form data currently available, if
        /// the veteran has data, it will repopulate that data, if not then just
        /// a blank form is displayed for step 3 
        /// </summary>
        /// <returns>IntakeFormViewModel3</returns>
        [HttpGet]
        public async Task<IActionResult> CreateStep3()
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

                veteranIntakeForm.CurrentStep = 3;
                _context.Update(veteranIntakeForm);
                await _context.SaveChangesAsync();

                return View(ifvm);
            }

            return View(ifvm);
        }

        /// <summary>
        /// Handles posting of the information input by the veteran
        /// </summary>
        /// <param name="intakeFormViewModel">IntakeFormViewModel3</param>
        /// <returns>View of create step 3</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateStep3([Bind("MonthlyIncome,BankAccountAssets,RealEstateAssets,LifeInsuranceCashValue," +
            "RetirementAccounts,StockBonds,Pension,BusinessInterest,MoneyOwedToYou,OtherAssetsOrMoney,Exit")
            ]IntakeFormViewModel3 intakeFormViewModel)
        {
            //if (ModelState.IsValid)
            //{
                VeteranIntakeForm currentForm = _context.VeteranIntakeForms.FirstOrDefault(form =>
                    form.VeteranApplicationUserId == _userManager.GetUserId(User) &&
                    form.IsCompleted == null
                );

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

                if (intakeFormViewModel.Exit != null)
                {
                    _context.VeteranIntakeForms.Update(currentForm);
                    await _context.SaveChangesAsync();
                    return RedirectToAction("Index", "Veteran");
                }

                currentForm.CurrentStep = 4;
                _context.VeteranIntakeForms.Update(currentForm);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(GoToStep), new { step = currentForm.CurrentStep });
            //}
            //return View(nameof(CreateStep3));
        }

        // LAST WILL AND TESTAMENT
        /// <summary>
        /// Checks to see if the veteran has form data currently available, if
        /// the veteran has data, it will repopulate that data, if not then just
        /// a blank form is displayed for step 4
        /// </summary>
        /// <returns>IntakeFormViewModel4</returns>
        [HttpGet]
        public async Task<IActionResult> CreateStep4()
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
                ifvm.DisinheritDescription = veteranIntakeForm.DisinheritDescription;
                ifvm.PrimaryGuardian = veteranIntakeForm.PrimaryGuardian;
                ifvm.AlternateGuardian = veteranIntakeForm.AlternateGuardian;
                ifvm.PersonalRepresentative = veteranIntakeForm.PersonalRepresentative;
                ifvm.AlternateRepresentative = veteranIntakeForm.AlternateRepresentative;

                veteranIntakeForm.CurrentStep = 4;
                _context.Update(veteranIntakeForm);
                await _context.SaveChangesAsync();

                return View(ifvm);
            }

            return View(ifvm);
        }

        /// <summary>
        /// Handles posting of the information input by the veteran
        /// </summary>
        /// <param name="intakeFormViewModel">IntakeFormViewModel4</param>
        /// <returns>View of create step 4</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateStep4(
            [Bind("HouseHoldSize,MaritalStatus,FullNameSpouse,HaveChildren,UnderAgeChildren,MinorChildrenDifferentSpouse,CurrentlyPregnant,SpecificBequest,BequestInfromation," +
            "InheritEstate,InheritEstateSpecific,RemainderBeneficiary,RemainderBeneficiarySpecific,DisinheritSomeone,DisinheritDescription,PrimaryGuardian,AlternateGuardian," +
            "PersonalRepresentative,AlternateRepresentative,Exit")]IntakeFormViewModel4 intakeFormViewModel)
        {
            //if (ModelState.IsValid)
            //{
                VeteranIntakeForm currentForm = _context.VeteranIntakeForms.FirstOrDefault(form =>
                    form.VeteranApplicationUserId == _userManager.GetUserId(User) &&
                    form.IsCompleted == null
                );

                //currentForm.CurrentStep = 5;
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
                currentForm.DisinheritDescription = intakeFormViewModel.DisinheritDescription;
                currentForm.PrimaryGuardian = intakeFormViewModel.PrimaryGuardian;
                currentForm.AlternateGuardian = intakeFormViewModel.AlternateGuardian;
                currentForm.PersonalRepresentative = intakeFormViewModel.PersonalRepresentative;
                currentForm.AlternateRepresentative = intakeFormViewModel.AlternateRepresentative;
                _context.VeteranIntakeForms.Update(currentForm);

                if (intakeFormViewModel.Exit != null)
                {
                    _context.VeteranIntakeForms.Update(currentForm);
                    await _context.SaveChangesAsync();
                    return RedirectToAction("Index", "Veteran");
                }

                currentForm.CurrentStep = 5;
                _context.VeteranIntakeForms.Update(currentForm);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(GoToStep), new { step = currentForm.CurrentStep });
            //}
            //return View(nameof(CreateStep4));
        }

        // POWER OF ATTORNEY
        /// <summary>
        /// Checks to see if the veteran has form data currently available, if
        /// the veteran has data, it will repopulate that data, if not then just
        /// a blank form is displayed for step 5 
        /// </summary>
        /// <returns>IntakeFormViewModel5</returns>
        [HttpGet]
        public async Task<IActionResult> CreateStep5()
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

                veteranIntakeForm.CurrentStep = 5;
                _context.Update(veteranIntakeForm);
                await _context.SaveChangesAsync();

                return View(ifvm);
            }

            return View(ifvm);
        }

        /// <summary>
        /// Handles posting of the information input by the veteran
        /// </summary>
        /// <param name="intakeFormViewModel">IntakeFormViewModel5</param>
        /// <returns>View of create step 5</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateStep5([Bind("RequestPowerOfAttorney,PrimaryAttorney,AlternateAttorney,Exit")]IntakeFormViewModel5 intakeFormViewModel)
        {
            //if (ModelState.IsValid)
            //{
                VeteranIntakeForm currentForm = _context.VeteranIntakeForms.FirstOrDefault(form =>
                    form.VeteranApplicationUserId == _userManager.GetUserId(User) &&
                    form.IsCompleted == null
                );

                //currentForm.CurrentStep = 6;
                currentForm.TimeStamp = DateTime.Now;

                currentForm.RequestPowerOfAttorney = intakeFormViewModel.RequestPowerOfAttorney;
                currentForm.PrimaryAttorney = intakeFormViewModel.PrimaryAttorney;
                currentForm.AlternateAttorney = intakeFormViewModel.AlternateAttorney;

                if (intakeFormViewModel.Exit != null)
                {
                    _context.VeteranIntakeForms.Update(currentForm);
                    await _context.SaveChangesAsync();
                    return RedirectToAction("Index", "Veteran");
                }

                currentForm.CurrentStep = 6;
                _context.VeteranIntakeForms.Update(currentForm);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(GoToStep), new { step = currentForm.CurrentStep });
            //}
            //return View(nameof(CreateStep5));
        }

        // HEALTHCARE DIRECTIVE
        /// <summary>
        /// Checks to see if the veteran has form data currently available, if
        /// the veteran has data, it will repopulate that data, if not then just
        /// a blank form is displayed for step 6 
        /// </summary>
        /// <returns>IntakeFormViewModel6</returns>
        [HttpGet]
        public async Task<IActionResult> CreateStep6()
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

                veteranIntakeForm.CurrentStep = 6;
                _context.Update(veteranIntakeForm);
                await _context.SaveChangesAsync();

                return View(ifvm);
            }

            return View(ifvm);
        }

        /// <summary>
        /// Handles posting of the information input by the veteran
        /// </summary>
        /// <param name="intakeFormViewModel">IntakeFormViewModel6</param>
        /// <returns>View of create step 6</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateStep6([Bind("HealthCareDirective,HydrationDirective,NutritionDirective,ArtificialVentilation,DistressMedication,Exit")]
        IntakeFormViewModel6 intakeFormViewModel)
        {
            //if (ModelState.IsValid)
            //{
                VeteranIntakeForm currentForm = _context.VeteranIntakeForms.FirstOrDefault(form =>
                    form.VeteranApplicationUserId == _userManager.GetUserId(User) &&
                    form.IsCompleted == null
                );

                //currentForm.CurrentStep = 7;
                currentForm.TimeStamp = DateTime.Now;

                currentForm.HealthCareDirective = intakeFormViewModel.HealthCareDirective;
                currentForm.HydrationDirective = intakeFormViewModel.HydrationDirective;
                currentForm.NutritionDirective = intakeFormViewModel.NutritionDirective;
                currentForm.ArtificialVentilation = intakeFormViewModel.ArtificialVentilation;
                currentForm.DistressMedication = intakeFormViewModel.DistressMedication;

                if (intakeFormViewModel.Exit != null)
                {
                    _context.VeteranIntakeForms.Update(currentForm);
                    await _context.SaveChangesAsync();
                    return RedirectToAction("Index", "Veteran");
                }
                currentForm.CurrentStep = 7;
                _context.VeteranIntakeForms.Update(currentForm);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(GoToStep), new { step = currentForm.CurrentStep });
            //}
            //return View(nameof(CreateStep6));
        }

        /// <summary>
        /// Checks to see if the veteran has form data currently available, if
        /// the veteran has data, it will repopulate that data, if not then just
        /// a blank form is displayed for step 7 
        /// </summary>
        /// <returns>IntakeFormViewModel7</returns>
        [HttpGet]
        public async Task<IActionResult> CreateStep7()
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

                veteranIntakeForm.CurrentStep = 7;
                _context.Update(veteranIntakeForm);
                await _context.SaveChangesAsync();

                return View(ifvm);
            }

            return View(ifvm);
        }

        /// <summary>
        /// Handles posting of the information input by the veteran
        /// </summary>
        /// <param name="intakeFormViewModel">IntakeFormViewModel7</param>
        /// <returns>View of create step 7</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateStep7([Bind("HealthPOA,PrimaryHealthAttorney,SecondaryHealthAttorney,Exit")]IntakeFormViewModel7 intakeFormViewModel)
        {
            //if (ModelState.IsValid)
            //{
                VeteranIntakeForm currentForm = _context.VeteranIntakeForms.FirstOrDefault(form =>
                    form.VeteranApplicationUserId == _userManager.GetUserId(User) &&
                    form.IsCompleted == null
                );

                //currentForm.CurrentStep = 8;
                currentForm.TimeStamp = DateTime.Now;

                currentForm.HealthPOA = intakeFormViewModel.HealthPOA;
                currentForm.PrimaryHealthAttorney = intakeFormViewModel.PrimaryHealthAttorney;
                currentForm.SecondaryHealthAttorney = intakeFormViewModel.SecondaryHealthAttorney;

                if (intakeFormViewModel.Exit != null)
                {
                    _context.VeteranIntakeForms.Update(currentForm);
                    await _context.SaveChangesAsync();
                    return RedirectToAction("Index", "Veteran");
                }
                currentForm.CurrentStep = 8;
                _context.VeteranIntakeForms.Update(currentForm);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(GoToStep), new { step = currentForm.CurrentStep });
            //}
            //return View(nameof(CreateStep7));
        }
        
        // SUMMARY
        /// <summary>
        /// Checks to see if the veteran has form data currently available, if
        /// the veteran has data, it will repopulate that data, if not then just
        /// a blank form is displayed for step 8 
        /// </summary>
        /// <returns>IntakeFormViewModel8</returns>
        [HttpGet]
        public IActionResult CreateStep8()
        {
            VeteranIntakeForm userForm = _context.VeteranIntakeForms.FirstOrDefault(form =>
                    form.VeteranApplicationUserId == _userManager.GetUserId(User) && 
                    form.IsCompleted == null);

            IntakeFormViewModelMaster ifvmm = new IntakeFormViewModelMaster
            {
                //TermsAndConditions = userForm.TermsAndConditions,
                FullLegalName = userForm.FullLegalName,
                Address = userForm.Address,
                PhoneNumber = userForm.PhoneNumber,
                VeteranStatus = userForm.VeteranStatus,
                ProofOfService = userForm.ProofOfService,
                ResidentStatus = userForm.ResidentStatus,
                NetWorth = userForm.NetWorth,
                MonthlyIncome = userForm.MonthlyIncome,
                BankAccountAssets = userForm.BankAccountAssets,
                RealEstateAssets = userForm.RealEstateAssets,
                LifeInsuranceCashValue = userForm.LifeInsuranceCashValue,
                RetirementAccounts = userForm.RetirementAccounts,
                StockBonds = userForm.StockBonds,
                Pension = userForm.Pension,
                BusinessInterest = userForm.BusinessInterest,
                MoneyOwedToYou = userForm.MoneyOwedToYou,
                OtherAssetsOrMoney = userForm.OtherAssetsOrMoney,
                HouseHoldSize = userForm.HouseHoldSize,
                MaritalStatus = userForm.MaritalStatus,
                FullNameSpouse = userForm.FullNameSpouse,
                HaveChildren = userForm.HaveChildren,
                UnderAgeChildren = userForm.UnderAgeChildren,
                MinorChildrenDifferentSpouse = userForm.MinorChildrenDifferentSpouse,
                CurrentlyPregnant = userForm.CurrentlyPregnant,
                SpecificBequest = userForm.SpecificBequest,
                BequestInfromation = userForm.BequestInfromation,
                InheritEstate = userForm.InheritEstate,
                InheritEstateSpecific = userForm.InheritEstateSpecific,
                RemainderBeneficiary = userForm.RemainderBeneficiary,
                RemainderBeneficiarySpecific = userForm.RemainderBeneficiarySpecific,
                DisinheritSomeone = userForm.DisinheritSomeone,
                DisinheritDescription = userForm.DisinheritDescription,
                PrimaryGuardian = userForm.PrimaryGuardian,
                AlternateGuardian = userForm.AlternateGuardian,
                PersonalRepresentative = userForm.PersonalRepresentative,
                AlternateRepresentative = userForm.AlternateRepresentative,
                RequestPowerOfAttorney = userForm.RequestPowerOfAttorney,
                PrimaryAttorney = userForm.PrimaryAttorney,
                AlternateAttorney = userForm.AlternateAttorney,
                HealthCareDirective = userForm.HealthCareDirective,
                HydrationDirective = userForm.HydrationDirective,
                NutritionDirective = userForm.NutritionDirective,
                ArtificialVentilation = userForm.ArtificialVentilation,
                DistressMedication = userForm.DistressMedication,
                HealthPOA = userForm.HealthPOA,
                PrimaryHealthAttorney = userForm.PrimaryHealthAttorney,
                SecondaryHealthAttorney = userForm.SecondaryHealthAttorney
            };

            return View(ifvmm);
        }

        /// <summary>
        /// Handles the completion of the form. Sets the IsCompleted property 
        /// to true and saves the completed form.
        /// </summary>
        /// <param name="intakeFormViewModel">IntakeFormViewModel1</param>
        /// <returns>View of create step 1</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateStep8(IntakeFormViewModelMaster ifvmm)
        {
            if (ModelState.IsValid)
            {
                VeteranIntakeForm currentForm = _context.VeteranIntakeForms.FirstOrDefault(form =>
                    form.VeteranApplicationUserId == _userManager.GetUserId(User) &&
                    form.IsCompleted == null
                );

                currentForm.IsCompleted = ifvmm.IsCompleted;
                currentForm.TimeStamp = DateTime.Now;

                _context.VeteranIntakeForms.Update(currentForm);
                await _context.SaveChangesAsync();

                return RedirectToAction("Index", "Veteran");
            }
            return View(ifvmm);
        }

        /// <summary>
        /// Takes the veteran back through the intake form process on a already completed
        /// form to make changes. 
        /// </summary>
        /// <param name="id">int id of the VeteranIntakeForm</param>
        /// <returns>RedirectToAction to Step 1</returns>
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            if (id == 0)
            {
                return RedirectToAction("Index", "Veteran");
             }
            
            var veteranIntakeForm = await _context.VeteranIntakeForms.SingleOrDefaultAsync(m => m.ID == id);

            if (veteranIntakeForm == null)
            {
                return RedirectToAction("Index", "Veteran");
            }

            //veteranIntakeForm.IsCompleted = null;

            _context.VeteranIntakeForms.Update(veteranIntakeForm);
            await _context.SaveChangesAsync();

            return RedirectToAction("GoToStep", new { step = 1 });
        }

        /// <summary>
        /// Updates the exsisting VeteranIntakeForm with the new information
        /// provided by the Veteran
        /// </summary>
        /// <param name="id">string id of the Veteran</param>
        /// <param name="veteranIntakeForm">VeteranIntakeForm object</param>
        /// <returns>View</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("ID,VeteranApplicationUserId,IsNotarized,TimeStamp,TermsAndConditions," +
            "FullLegalName,Address,PhoneNumber,VeteranStatus,ProofOfService,ResidentStatus,NetWorth,BankAccountAssets,RealEstateAssets," +
            "LifeInsuranceCashValue,RetirementAccounts,StockBonds,Pension,BusinessInterest,MoneyOwedToYou,OtherAssetsOrMoney,HouseHoldSize," +
            "MonthlyIncome,MaritalStatus,FullNameSpouse,HaveChildren,UnderAgeChildren,MinorChildrenDifferentSpouse,CurrentlyPregnant," +
            "SpecificBequest,BequestInfromation,InheritEstate,InheritEstateSpecific,RemainderBeneficiary,RemainderBeneficiarySpecific," +
            "DisinheritSomeone,DisinherentDescription,PrimaryGuardian,AlternateGuardian,PersonalRepresentative,AlternateRepresentative," +
            "RequestPowerOfAttorney,PrimaryAttorney,AlternateAttorney,HealthCareDirective,HydrationDirective,NutritionDirective," +
            "ArtificialVentilation,DistressMedication")] VeteranIntakeForm veteranIntakeForm)
        {
            if (id != veteranIntakeForm.VeteranApplicationUserId)
            {
                return NotFound();
            }
            
            if (ModelState.IsValid)
            {
                try
                {
                    //veteranIntakeForm.IsCompleted = true;
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

        /// <summary>
        /// Deletes a specified Intake Form
        /// </summary>
        /// <param name="id">string id of Veteran</param>
        /// <returns>View</returns>
        [HttpGet]
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var veteranIntakeForm = await _context.VeteranIntakeForms
                .SingleOrDefaultAsync(m => m.ID == int.Parse(id));

            if (veteranIntakeForm == null)
            {
                return NotFound();
            }

            return View(veteranIntakeForm);
        }

        // TODO: Needs to redirect to the new razor pages profile home 
        /// <summary>
        /// Completes the deletion of the form and updates the DB
        /// </summary>
        /// <param name="id">int id of the form</param>
        /// <returns>RedirectToAction of the Veteran Index page</returns>
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var veteranIntakeForm = await _context.VeteranIntakeForms.SingleOrDefaultAsync(m => m.ID == id);
            _context.VeteranIntakeForms.Remove(veteranIntakeForm);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "Veteran");
        }


        private bool VeteranIntakeFormExists(string id)
        {
            return _context.VeteranIntakeForms.Any(e => e.VeteranApplicationUserId == id);
        }
    }
}
