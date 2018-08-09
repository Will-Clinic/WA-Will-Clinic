using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using SendGrid;
using SendGrid.Helpers.Mail;
using WillClinic.Data;
using WillClinic.Models;
using WillClinic.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

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

        public EmailConfirmationModel(UserManager<ApplicationUser> userManager,
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

        /// <summary>
        /// The link sent by email should directly connect to this method. It will switch confirmed email to true and redirect as appropriate
        /// </summary>
        /// <param name="id">Id of the user in the link</param>
        /// <param name="code">Generated confirmation code for that user</param>
        /// <param name="expectedRole">the role that user is attempting to aquire</param>
        /// <returns>redirect to email confirmed for vets, bar number entry for lawyers</returns>
        [HttpPost]
        public async Task<IActionResult> OnGet(string id, string code, string SelectedUserType)
        {
            ApplicationUser user = await _userManager.FindByIdAsync(id);

            if (!string.IsNullOrWhiteSpace(code) &&
                (await _userManager.ConfirmEmailAsync(user, code)).Succeeded)
            {
                //If link is valid, set email confirmed to true for the account.
                user.EmailConfirmed = true;
                await _userManager.UpdateAsync(user);

                if (ModelState.IsValid)
                {
                    string fullname = $"{user.FirstName} {user.MiddleInitial} {user.LastName}";
                    Claim name = new Claim(ClaimTypes.Name, fullname, ClaimValueTypes.String);
                    Claim userEmail = new Claim(ClaimTypes.Email, user.Email, ClaimValueTypes.String);
                    List<Claim> claims = new List<Claim> { name, userEmail };
                    await _userManager.AddClaimsAsync(user, claims);

                    //If the link is for a lawyer account, redirect to lawyer confirmation page
                    if (SelectedUserType == ApplicationRoles.Lawyer)
                    {
                        Email = user.Email;
                        return RedirectToPage("/Accounts/LawyerVerification");
                    }

                    else if (SelectedUserType == ApplicationRoles.Veteran)
                    {
                        //Create veteran role if it does not exist
                        if (!await _roleManager.RoleExistsAsync(ApplicationRoles.Veteran))
                        {
                            await _roleManager.CreateAsync(new IdentityRole(ApplicationRoles.Veteran));
                        }

                        if (ModelState.IsValid)
                        {

                            // Adding Role to Veteran account
                            await _userManager.AddToRoleAsync(user, ApplicationRoles.Veteran);

                            // Populate Veteran Table with new account
                            Veteran newVet = new Veteran { ApplicationUserId = user.Id };
                            await _context.Veterans.AddAsync(newVet);
                            await _context.SaveChangesAsync();
                        }
                        return RedirectToPage("/Accounts/EmailConfirmed");
                    }
                }
            }
            //Catch all default for when the link is invalid
            ViewData["error"] = "Something went wrong with your confirmation, your link may have been damaged.";
            return RedirectToPage(nameof(RegisterModel));
            //TODO create page that will resend confirmation email with valid link
        }
    }
}

