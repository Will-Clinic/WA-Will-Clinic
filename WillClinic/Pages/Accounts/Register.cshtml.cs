using System;
using System.Collections.Generic;
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
        [BindProperty]
        public SelectList UserType { get; set; }

        public RegisterModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            UserType = new SelectList(new string[] { ApplicationRoles.Veteran, ApplicationRoles.Lawyer });
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