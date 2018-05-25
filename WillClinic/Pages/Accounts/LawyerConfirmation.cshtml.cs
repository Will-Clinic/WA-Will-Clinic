using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WillClinic.Models;
using WillClinic.Services;

namespace WillClinic.Pages.Accounts
{
    public class LawyerConfirmationModel : PageModel
    {
        internal int BarNumber;
        private string Email;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly LawyerVerificationService _verify;

        public LawyerConfirmationModel (UserManager<ApplicationUser> userManager, LawyerVerificationService lawyerVerificationService )
        {
            _userManager = userManager;
            _verify = lawyerVerificationService;
        }

        public async Task OnGetAsync(string email, string code, string userType)
        {
            Email = email;
            ApplicationUser user = await _userManager.FindByEmailAsync(email);

            if (!string.IsNullOrWhiteSpace(code) &&
                (await _userManager.ConfirmEmailAsync(user, code)).Succeeded)
            {
                if (userType == ApplicationRoles.Lawyer)
                {
                    //return RedirectToPage(nameof());
                }
                user.EmailConfirmed = true;
                await _userManager.UpdateAsync(user);
            }
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (await _verify.IsValidLawyerAsync(BarNumber, Email))
            {
                //TODO add claims, roles, etc
                return RedirectToAction("Index", "Home");
            }
            else
            {
                //TODO add more here
                ViewData["error"] = "Sorry, but checking your information against the Washington State Bar Association produced an error.";
                return RedirectToAction("Index", "Home");
            }
        }
    }
}