using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using WillClinic.Data;
using WillClinic.Models;
using WillClinic.Models.AccountViewModels;
using WillClinic.Services;

namespace WillClinic.Controllers
{
    [Authorize]
    [Route("[controller]/[action]")]
    public class LawyerController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ApplicationDbContext _context;
        private readonly IEmailSender _emailSender;
        private readonly ILogger _logger;

        public LawyerController(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            ApplicationDbContext context,
            IEmailSender emailSender,
            ILogger<LawyerController> logger)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;
            _emailSender = emailSender;
            _logger = logger;
        }

        [HttpGet]
        [Authorize(Roles = "Lawyer")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Register(string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterLawyerViewModel model, string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser { UserName = model.Email, Email = model.Email, FirstName = model.FirstName, MiddleInitial = model.MiddleInitial, LastName = model.LastName };
                var result = await _userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    _logger.LogInformation("User created a new account with password.");
                    
                    // Setting up claims for the Lawyer
                    string fullname = $"{model.FirstName} {model.MiddleInitial}. {model.LastName}";
                    Claim name = new Claim(ClaimTypes.Name, fullname, ClaimValueTypes.String);
                    Claim email = new Claim(ClaimTypes.Email, model.Email, ClaimValueTypes.String);
                    List<Claim> claims = new List<Claim> { name, email };
                    await _userManager.AddClaimsAsync(user, claims);

                    // Adding Role to Lawyer account
                    await _userManager.AddToRoleAsync(user, ApplicationRoles.Lawyer);

                    // Populate Lawyer Table with new account
                    Lawyer newLaw = new Lawyer { ApplicationUserId = user.Id, BarNumber = model.BarNumber, City = model.City, Country = model.Country, IsVerified = false, OtherLanguages = model.OtherLanguages, PracticeAreas = model.PracticeAreas, State = model.State, YearsOfExperience = model.YearsOfExperience, ZipCode = model.ZipCode };
                    await _context.Lawyers.AddAsync(newLaw);
                    await _context.SaveChangesAsync();

                    var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    var callbackUrl = Url.EmailConfirmationLink(user.Id, code, Request.Scheme);
                    await _emailSender.SendEmailConfirmationAsync(model.Email, callbackUrl);

                    await _signInManager.SignInAsync(user, isPersistent: false);
                    _logger.LogInformation("User created a new account with password.");
                    return RedirectToLocal(returnUrl);
                }
                AddErrors(result);
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        #region Helpers

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }
        }

        private IActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                return RedirectToAction(nameof(HomeController.Index), "Home");
            }
        }

        #endregion
    }
}
