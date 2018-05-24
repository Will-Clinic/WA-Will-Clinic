using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using WillClinic.Data;
using WillClinic.Models;

namespace WillClinic.Pages.Accounts
{
    public class RegisterModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        [BindProperty]
        public ApplicationUser ApplicationUser { get; set; }
        /// <summary>
        /// Gathers the type of user that is registered to be used to determine
        /// which verification e-mail to send out. Should match the values found
        /// in ApplicationRoles for Veteran and Lawyer
        /// </summary>
        [BindProperty]
        [Display(Name = "User Type")]
        public string SelectedUserType { get; set; }
        public SelectList UserTypes { get; set; }

        public RegisterModel(ApplicationDbContext context)
        {
            _context = context;
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

            _context.ApplicationUser.Add(ApplicationUser);
            await _context.SaveChangesAsync();

            // TODO(taylorjoshuaw): Add email service call to send either a veteran or lawyer verification link
            //                      to the user

            return RedirectToPage("./EmailVerificationSent");
        }
    }
}