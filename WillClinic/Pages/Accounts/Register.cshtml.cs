using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using WillClinic.Data;
using WillClinic.Models;
using WillClinic.Services;

namespace WillClinic.Pages.Accounts
{
    public class RegisterModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        private EmailSender _emailSender { get; set; }
        private UserManager<ApplicationUser> _userManager { get; set; }

        [BindProperty]
        public ApplicationUser NewUser { get; set; }
        /// <summary>
        /// Gathers the type of user that is registered to be used to determine
        /// which verification e-mail to send out. Should match the values found
        /// in ApplicationRoles for Veteran and Lawyer
        /// </summary>
        [BindProperty]
        [Display(Name = "User Type")]
        public string SelectedUserType { get; set; }
        public SelectList UserTypes { get; set; }

        public RegisterModel(ApplicationDbContext context, EmailSender emailSender, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _emailSender = emailSender;
            _userManager = userManager;
        }

        public IActionResult OnGet()
        {
            UserTypes = new SelectList(new string[] { ApplicationRoles.Veteran, ApplicationRoles.Lawyer });
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.ApplicationUser.Add(NewUser);
            await _context.SaveChangesAsync();
            
            string code = await _userManager.GenerateEmailConfirmationTokenAsync(NewUser);

            //TODO refactor this to use pages
            string link = Url.Action("Verify", "Acount",
                new { email = NewUser.Email, code, userType = SelectedUserType }, "https", HttpContext.Request.Host.Value);

            await _emailSender.SendEmailConfirmationAsync(NewUser.Email, link);

            return RedirectToPage("./EmailVerificationSent");
        }
    }
}