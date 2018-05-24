using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WillClinic.Models;

namespace WillClinic.Pages.Accounts
{
    public class LawyerConfirmationModel : PageModel
    {
        internal int BarNumber;
        private string Email;
        private readonly UserManager<ApplicationUser> _userManager;

        public LawyerConfirmationModel (UserManager<ApplicationUser> userManager )
        {
            _userManager = userManager;
        }

        public async Task OnGetAsync(string email, string code)
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

        public void OnPost()
        {
        }
    }
}