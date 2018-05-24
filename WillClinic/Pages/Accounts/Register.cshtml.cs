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
        private readonly EmailSender _emailSender;
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

        public RegisterModel(ApplicationDbContext context, EmailSender emailSender, UserManager<ApplicationUser> userManager, IConfiguration configuration)
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

            _context.ApplicationUser.Add(NewUser);
            await _context.SaveChangesAsync();
            
            string code = await _userManager.GenerateEmailConfirmationTokenAsync(NewUser);

            if (SelectedUserType == ApplicationRoles.Lawyer)
            {
                string verifyLink = Url.Page(nameof(LawyerConfirmationModel), "OnGet",
                    new { email = NewUser.Email, code }, "https", HttpContext.Request.Host.Value);

            }
            else
            {
                //TODO verify non-lawyers
                //string verifyLink = Url.Page(nameof(), "Account",
                  //  new { email = NewUser.Email, code, userType = SelectedUserType }, "https", HttpContext.Request.Host.Value);

            }


            // Compose the e-mail message to send to the user
            var message = new SendGridMessage()
            {
                From = new EmailAddress("donotreply@wavetswillclinic.com/", "Washington Veteran Will Clinic"),
                Subject = "Verify Your Veteran Will Clinic",
                HtmlContent = $"<h3>Veteran Will Clinic</h3><h4>Please verify your account by clicking the link below:</h4><a href=\"{verifyLink}\">{verifyLink}</a>",
                PlainTextContent = $"Please copy and paste the following link into your browser's address bar: {verifyLink}"
            };

            var client = new SendGridClient(_configuration["SendGridAPIKey"]);

            //Sending the email
            var response = await client.SendEmailAsync(message);

            return RedirectToPage("./EmailVerificationSent");
        }
    }
}