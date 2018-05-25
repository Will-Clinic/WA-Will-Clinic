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
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManger;
        private readonly ILawyerVerificationService _verificationService;
        internal string Email { get; set; }
        internal string City { get; set; }
        internal string State { get; set; }
        internal string Country { get; set; }
        internal int Zip { get; set; }
        internal string PracticeAreas { get; set; }
        internal int YearsOfExperience { get; set; }
        internal bool OtherLanguages { get; set; } //TODO this is a placeholder
        internal int BarNumber { get; set; }
        private ApplicationDbContext _context;

        public EmailConfirmationModel (UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, LawyerVerificationService verificationService, ApplicationDbContext context)
        {
            _userManager = userManager;
            _signInManger = signInManager;
            _verificationService = verificationService;
            _context = context;
        }

        public void OnGet()
        {

        }

        public async Task OnPostAsync()
        {
            if (await _verificationService.IsValidLawyerAsync(BarNumber, Email))
            {
                var user = await _userManager.FindByEmailAsync(Email);
                        // Setting up claims for the Lawyer
                        Claim name = new Claim(ClaimTypes.Name, user.FirstName + user.MiddleInitial + user.LastName, ClaimValueTypes.String);
                        Claim email = new Claim(ClaimTypes.Email, user.Email, ClaimValueTypes.String);
                        List<Claim> claims = new List<Claim> { name, email };
                        await _userManager.AddClaimsAsync(user, claims);


                        // Adding Role to Lawyer account
                        await _userManager.AddToRoleAsync(user, ApplicationRoles.Lawyer);

                // Populate Lawyer Table with new account
                Lawyer newLaw = new Lawyer { ApplicationUserId = user.Id,
                    BarNumber = BarNumber,
                    City = City,
                    Country = Country,
                    //IsVerified = false, 
                    IsRejected = false,
                    OtherLanguages = OtherLanguages, 
                    PracticeAreas = PracticeAreas,
                    State = State,
                    YearsOfExperience = YearsOfExperience,
                    ZipCode = Zip
                        };
                        await _context.Lawyers.AddAsync(newLaw);
                        await _context.SaveChangesAsync();
                    }
            else
            {
                //TODO display error as not being a valid lawyer
            }
        }

        [HttpPost]
        public async Task<IActionResult> OnLinkAsync(string email, string code, string expectedRole)
        {
            ApplicationUser user = await _userManager.FindByEmailAsync(email);

            if (!string.IsNullOrWhiteSpace(code) &&
                (await _userManager.ConfirmEmailAsync(user, code)).Succeeded)
            {
                user.EmailConfirmed = true;
                await _userManager.UpdateAsync(user);
                if (expectedRole == ApplicationRoles.Lawyer)
                {
                    Email = email;
                    return Page();
                }
                else
                {
                    //TODO add claims/role as a veteran
                    return RedirectToPage("./AccountConfirmed");
                }
            }
            else
            {
                ViewData["error"] = "Something went wrong with your confirmation";
                return RedirectToPage(nameof(RegisterModel));
            }
        }
    }
}