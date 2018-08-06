using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WillClinic.Data;
using WillClinic.Models;
using WillClinic.Services;

namespace WillClinic.Pages.Accounts
{
    public class EmailConfirmationModel : PageModel
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManger;
        private readonly ILawyerVerificationService _verificationService;
        public string Email { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public int Zip { get; set; }
        public string PracticeAreas { get; set; }
        public int YearsOfExperience { get; set; }
        public bool OtherLanguages = false; //TODO this is a placeholder. Add a feature or delete in next iteration.
        public int BarNumber { get; set; }
        private ApplicationDbContext _context;

        public EmailConfirmationModel (UserManager<ApplicationUser> userManager,
                                       SignInManager<ApplicationUser> signInManager, 
                                       ILawyerVerificationService verificationService, 
                                       ApplicationDbContext context,
                                       RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _signInManger = signInManager;
            _verificationService = verificationService;
            _context = context;
            _roleManager = roleManager;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        /// <summary>
        /// This action only occurs when a lawyer has posted their bar number.
        /// </summary>
        /// <returns>Add lawyer to the role if appropriate</returns>
        public async Task<IActionResult> OnPostAsync()
        {
            var user = await _userManager.FindByEmailAsync(Email);
            if (await _verificationService.IsValidLawyerAsync(BarNumber, Email) && user.EmailConfirmed)
            {
                if (!await _roleManager.RoleExistsAsync("Lawyer"))
                {
                    await _roleManager.CreateAsync(new IdentityRole("Lawyer"));
                }

                // Adding Role to Lawyer account
                await _userManager.AddToRoleAsync(user, ApplicationRoles.Lawyer);

                // Populate Lawyer Table with new account
                Lawyer newLaw = new Lawyer
                {
                    ApplicationUserId = user.Id,
                    BarNumber = BarNumber,
                    City = City,
                    Country = Country,
                    IsVerified = true,
                    IsRejected = false,
                    OtherLanguages = OtherLanguages,
                    PracticeAreas = PracticeAreas,
                    State = State,
                    YearsOfExperience = YearsOfExperience,
                    ZipCode = Zip
                };

                await _context.Lawyers.AddAsync(newLaw);
                await _context.SaveChangesAsync();

                //Everything went well, simply redirect to email confirmed page
                return RedirectToPage("./EmailConfirmed");
            }
            else if (user.EmailConfirmed == false)
            {
                //cannot confirm a lawyer until email is confirmed
                //lawyer confirmation checks email against the listed email with
                //the WSBA. If they match, lawyer is valid. If email is unconfirmed,
                //faking being a lawyer would be easy.
                ViewData["error"] = "Your email has not been confirmed.";
                return Page();
            }
            else
            {
                //The WSBA information does not return a valid lawyer. At least one of the following is true:
                //the email the WSBA has for that bar number is not the confirmed email for the account
                //the WSBA info says that person is licensed but not as a lawyer
                //the WSBA info say that person is not currently eligible to practice
                //the WSBA has changed their public facing legal directory -- tests should be failing.s
                ViewData["error"] = "The bar number provided does not match the information provided by the Washington State Bar Association, or your license type is not lawyer, or you are not currently eligible to practice. To correct any of these concerns, please contact the WSBA to update their records or create a new account with the matching email address.";
                return Page();
            }
        }
    }
}