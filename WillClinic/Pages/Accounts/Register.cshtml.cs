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


namespace WillClinic.Pages.Accounts
{
    public class RegisterModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        private readonly IEmailSender _emailSender;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IConfiguration _configuration;

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

        [Required]
        [StringLength(80, MinimumLength = 6)]
        [BindProperty]
        [Display(Name = nameof(Password))]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Compare(nameof(Password), ErrorMessage = "Passwords do not match")]
        public string ConfirmPassword { get; set; }

        public RegisterModel(ApplicationDbContext context, IEmailSender emailSender, UserManager<ApplicationUser> userManager, IConfiguration configuration)
        {
            _context = context;
            _emailSender = emailSender;
            _userManager = userManager;
            _configuration = configuration;
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

            await _userManager.CreateAsync(NewUser, Password);
            await _context.SaveChangesAsync();

            //Set up email verification
            //Building verification email with link
            string code = await _userManager.GenerateEmailConfirmationTokenAsync(NewUser);

            string verifyLink = Url.Page(nameof(EmailConfirmationModel), nameof(EmailConfirmationModel.OnLinkAsync),
                    new { email = NewUser.Id, code, SelectedUserType }, "https", HttpContext.Request.Host.Value);


            // Compose the e-mail message to send to the user
            string subject = "Verify Your Veteran Will Clinic Account";
            string htmlContent = $"<h3>Veteran Will Clinic</h3><h4>Please verify your account by clicking the link below:</h4><a href=\"{verifyLink}\">{verifyLink}</a>";
            string plainTextContent = $"Please copy and paste the following link into your browser's address bar: {verifyLink}";

            //Send the email
            await _emailSender.SendEmailAsync(NewUser.Email, subject, htmlContent, plainTextContent);

            return RedirectToPage("./EmailVerificationSent");
        }
    }
}