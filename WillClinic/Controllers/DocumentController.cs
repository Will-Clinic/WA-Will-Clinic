using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DinkToPdf;
using DinkToPdf.Contracts;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WillClinic.Data;
using WillClinic.Models;
using WillClinic.Models.Documents;

namespace WillClinic.Controllers
{
    public class DocumentController : Controller
    {
        private ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public DocumentController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // TODO Create and index action that lists all previous documents
        public IActionResult Index()
        {
            return View();
        }

        // TODO Create an Edit Action that allows Lawyers to make changes to the documents 

        /// <summary>
        /// Action to display the populated documents for confirmation.
        /// </summary>
        /// <param name="id">Veteran ID</param>
        /// <returns>Returns a populated AllDocs View Model that will render into a legal document</returns>
        [HttpGet]
        public async Task<IActionResult> Confirmation(int? id)
        {
            var user = await _userManager.GetUserAsync(User);
            var veteranIntakeForm = await _context.VeteranIntakeForms.SingleOrDefaultAsync(m => m.VeteranApplicationUserId == user.Id);

            //This is a hard coded view model. Production will use linq quires to populate the model based on the Veteran ID
            AllDocsViewModel vm = new AllDocsViewModel()
            {
                FirstName = veteranIntakeForm.FullLegalName.ToUpper(),
                //MiddleName = user.MiddleInitial.ToUpper(),
                //LastName = user.LastName.ToUpper(),
                
                // Not being asked
                County = "King",

                MaritalStatus = veteranIntakeForm.MaritalStatus.ToString(),
                SpouseName = veteranIntakeForm.FullNameSpouse,
                HasChildren = veteranIntakeForm.HaveChildren.Value,

                // Not being asked
                Children = new List<string> { " Jack ", " Kira "},

                PRPrimeFirstName = veteranIntakeForm.PrimaryGuardian,
                PRPrimeLastName = "",
                PRAltFirstName = veteranIntakeForm.AlternateGuardian,
                PRAltLastName = "",
                PrimeBenificiary = veteranIntakeForm.InheritEstate + " " + veteranIntakeForm.InheritEstateSpecific,
                AltBenificiary = veteranIntakeForm.RemainderBeneficiary + " " + veteranIntakeForm.RemainderBeneficiarySpecific,
                DisposeList = new List<string> { "None"},
                SuccessorPrime = veteranIntakeForm.PrimaryAttorney,
                SuccessorAlt = veteranIntakeForm.AlternateAttorney
            };
            return View(vm);
        }
    }
}
