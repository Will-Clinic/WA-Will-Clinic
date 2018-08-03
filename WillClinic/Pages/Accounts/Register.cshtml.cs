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

namespace WillClinic.Pages.Accounts
{
    public class RegisterModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        private readonly IEmailSender _emailSender;
        private UserManager<ApplicationUser> _userManager;
        private readonly IConfiguration _configuration;
        private readonly ILogger<RegisterModel> _logger;

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

        public RegisterModel(ApplicationDbContext context, IEmailSender emailSender, UserManager<ApplicationUser> userManager,
            IConfiguration configuration, ILogger<RegisterModel> logger)
        {
            _context = context;
            _emailSender = emailSender;
            _userManager = userManager;
            _configuration = configuration;
            _logger = logger;
        }

        /// <summary>
        /// Present the user with a form for entering their information for an account and the type of account they would like to create
        /// </summary>
        /// <returns>PageResult for the /Accounts/Register page</returns>
        public IActionResult OnGet()
        {
            // Populate the SelectList used to specify which type of account the user would like to create.
            UserTypes = new SelectList(new string[] { ApplicationRoles.Veteran, ApplicationRoles.Lawyer });
            return Page();
        }

        ///// <summary>
        ///// Attempts to create a new user account and to send a verification email to the user containing a link
        ///// needed to confirm their email address as well as creating their lawyer or veteran profile based on the
        ///// selection provided in the form presented in the GET handler
        ///// </summary>
        ///// <returns>RedirectToPageResult for /Accounts/EmailVerificationSent upon success.
        ///// HTTP 500 if the user account could not be created in the database. HTTP 503 if the verification email
        ///// was not able to be sent</returns>
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            NewUser.UserName = NewUser.Email;

            var result = await _userManager.CreateAsync(NewUser, Password);
            if (result.Succeeded)
            {

            }
            // NOTE(taylorjoshuaw): User creation should be refactored into a service!
            // Attempt to commit user creation to the database
            //try
            //{
            //    //await _context.SaveChangesAsync();
            //}
            //catch
            //{
            //    // Log the error and return a 500 error to indicate an error commiting the new user to the database
            //    _logger.LogError("Unable to create user upon POST of user creation form");
            //    return StatusCode(StatusCodes.Status500InternalServerError);
            //}

            // Set up email verification
            // Building verification email with link
            string code = await _userManager.GenerateEmailConfirmationTokenAsync(NewUser);

            //string verifyLink = Url.Page(nameof(EmailConfirmationModel), nameof(EmailConfirmationModel.OnLinkAsync),
            //        new { email = NewUser.Id, code, SelectedUserType }, "https", HttpContext.Request.Host.Value);

            string verifyLink = Url.Page("/Accounts/EmailConfirmed", "OnGet",
        new { email = NewUser.Id, code, SelectedUserType }, "https", HttpContext.Request.Host.Value);


            // Compose the e-mail message to send to the user
            string subject = "Verify Your Veteran Will Clinic Account";
            string htmlContent = $"<h3>Veteran Will Clinic</h3><h4>Please verify your account by clicking the link below:</h4><a href=\"{verifyLink}\">{verifyLink}</a>";
            string plainTextContent = $"Please copy and paste the following link into your browser's address bar: {verifyLink}";

            // Attempt to send the verification email
            if (await _emailSender.SendEmailAsync(NewUser.Email, subject, htmlContent, plainTextContent))
            {
                return RedirectToPage("./EmailVerificationSent");
            }

            // Something went wrong. The error has already been logged in SendEmailAsync, so just return a 503 to indicate
            // an issue occurred with the email service
            return StatusCode(StatusCodes.Status503ServiceUnavailable);
        }
    }
}