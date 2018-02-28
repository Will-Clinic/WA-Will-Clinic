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

        // GET: VeteranIntakeForm/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var veteranIntakeForm = await _context.VeteranIntakeForms
                .SingleOrDefaultAsync(m => m.VeteranApplicationUserId == id);
            if (veteranIntakeForm == null)
            {
                return NotFound();
            }

            return View(veteranIntakeForm);
        }

        // GET: VeteranIntakeForm/Create
        public IActionResult GoToStep(byte step = 0)
        {
            if (step == 1) return RedirectToAction(nameof(CreateStep1));
            if (step == 2) return RedirectToAction(nameof(CreateStep2));
            if (step == 3) return RedirectToAction(nameof(CreateStep3));
            if (step == 4) return RedirectToAction(nameof(CreateStep4));
            return RedirectToAction(nameof(CreateStep0));
        }

        // GET: VeteranIntakeForm/CreateStep0
        public IActionResult CreateStep0()
        {
            return View();
        }

        // POST: VeteranIntakeForm/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateStep0(bool termsAndConditions)
        {
            if (termsAndConditions)
            {
                VeteranIntakeForm veteranIntakeForm = new VeteranIntakeForm();
                veteranIntakeForm.TimeStamp = DateTime.Now;
                veteranIntakeForm.CurrentStep = 1;
                veteranIntakeForm.VeteranApplicationUserId = _userManager.GetUserId(User);
                veteranIntakeForm.TermsAndConditions = termsAndConditions;
                await _context.AddAsync(veteranIntakeForm);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(GoToStep), new { step = veteranIntakeForm.CurrentStep });
            }
            return View(nameof(CreateStep0));
        }

        // GET: VeteranIntakeForm/CreateStep1
        public IActionResult CreateStep1()
        {
            return View();
        }

        // POST: VeteranIntakeForm/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateStep1([Bind("FullLegalName,Address,PhoneNumber")] IntakeFormViewModel intakeFormViewModel)
        {
            if (ModelState.IsValid)
            {
                VeteranIntakeForm currentForm = _context.VeteranIntakeForms.FirstOrDefault(form =>
                    form.VeteranApplicationUserId == _userManager.GetUserId(User) &&
                    form.IsCompleted == false
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

        // GET: VeteranIntakeForm/CreateStep2
        public IActionResult CreateStep2()
        {
            return View();
        }
        // GET: VeteranIntakeForm/CreateStep3
        public IActionResult CreateStep3()
        {
            return View();
        }
        // GET: VeteranIntakeForm/CreateStep4
        public IActionResult CreateStep4()
        {
            return View();
        }

        // GET: VeteranIntakeForm/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var veteranIntakeForm = await _context.VeteranIntakeForms.SingleOrDefaultAsync(m => m.VeteranApplicationUserId == id);
            if (veteranIntakeForm == null)
            {
                return NotFound();
            }
            return View(veteranIntakeForm);
        }

        // POST: VeteranIntakeForm/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("ID,VeteranApplicationUserId,IsNotarized,TimeStamp,TermsAndConditions,FullLegalName,Address,PhoneNumber,VeteranStatus,ProofOfService,ResidentStatus,NetWorth,BankAccountAssets,RealEstateAssets,LifeInsuranceCashValue,RetirementAccounts,StockBonds,Pension,BusinessInterest,MoneyOwedToYou,OtherAssetsOrMoney,HouseHoldSize,MonthlyIncome,MaritalStatus,FullNameSpouse,HaveChildren,UnderAgeChildren,MinorChildrenDifferentSpouse,CurrentlyPregnant,SpecificBequest,BequestInfromation,InheritEstate,InheritEstateSpecific,RemainderBeneficiary,RemainderBeneficiarySpecific,DisinheritSomeone,DisinherentDescription,PrimaryGuardian,AlternateGuardian,PersonalRepresentative,AlternateRepresentative,RequestPowerOfAttorney,PrimaryAttorney,AlternateAttorney,HealthCareDirective,HydrationDirective,NutritionDirective,ArtificialVentilation,DistressMedication")] VeteranIntakeForm veteranIntakeForm)
        {
            if (id != veteranIntakeForm.VeteranApplicationUserId)
            {
                return NotFound();
            }

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
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(VeteranController.Index));
            }
            return View(veteranIntakeForm);
        }

        // GET: VeteranIntakeForm/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var veteranIntakeForm = await _context.VeteranIntakeForms
                .SingleOrDefaultAsync(m => m.VeteranApplicationUserId == id);
            if (veteranIntakeForm == null)
            {
                return NotFound();
            }

            return View(veteranIntakeForm);
        }

        // POST: VeteranIntakeForm/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var veteranIntakeForm = await _context.VeteranIntakeForms.SingleOrDefaultAsync(m => m.VeteranApplicationUserId == id);
            _context.VeteranIntakeForms.Remove(veteranIntakeForm);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(VeteranController.Index));
        }

        private bool VeteranIntakeFormExists(string id)
        {
            return _context.VeteranIntakeForms.Any(e => e.VeteranApplicationUserId == id);
        }
    }
}
