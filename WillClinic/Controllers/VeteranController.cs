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
    // Recommend using resource-specific authorization in the future to keep veterans from accessing eachother's forms.
    // https://docs.microsoft.com/en-us/aspnet/core/security/authorization/resourcebased?tabs=aspnetcore2x
    [Authorize]
    [Route("[controller]/[action]")]
    public class VeteranController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IEmailSender _emailSender;
        private readonly ILogger _logger;
        private readonly ApplicationDbContext _context;

        public VeteranController(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            IEmailSender emailSender,
            ILogger<AccountController> logger,
            ApplicationDbContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _emailSender = emailSender;
            _logger = logger;
            _context = context;
        }

        [HttpGet]
        [Authorize(Roles = "Veteran")]
        public IActionResult Index()
        {
            string userID = _userManager.GetUserId(User);

            // VeteranIntakeForm currentForm = _context.VeteranIntakeForms.FirstOrDefault(f => f.);
            List<VeteranIntakeForm> intakeForms = new List<VeteranIntakeForm>();
            
            intakeForms = _context.VeteranIntakeForms.Where(f => f.VeteranApplicationUserId == userID).ToList();

            return View(intakeForms);
        }

        /// <summary>
        /// Open Veteran Registration Page
        /// </summary>
        /// <param name="returnUrl">return to the previous page</param>
        /// <returns></returns>
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Register(string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }


        /// <summary>
        /// Register a new Veteran using the veteran view model
        /// </summary>
        /// <param name="model"></param>
        /// <param name="returnUrl"></param>
        /// <returns></returns>
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterVeteranViewModel model, string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser { UserName = model.Email, Email = model.Email, FirstName = model.FirstName, MiddleInitial = model.MiddleInitial, LastName = model.LastName };
                var result = await _userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    _logger.LogInformation("User created a new account with password.");

                    // Setting up claims for the Veteran
                    string fullname = $"{model.FirstName} {model.MiddleInitial}. {model.LastName}";
                    Claim name = new Claim(ClaimTypes.Name, fullname, ClaimValueTypes.String);
                    Claim email = new Claim(ClaimTypes.Email, model.Email, ClaimValueTypes.String);
                    List<Claim> claims = new List<Claim> { name, email };
                    await _userManager.AddClaimsAsync(user, claims);

                    // Adding Role to Veteran account
                    await _userManager.AddToRoleAsync(user, ApplicationRoles.Veteran);

                    // Populate Veteran Table with new account
                    Veteran newVet = new Veteran { ApplicationUserId = user.Id };
                    await _context.Veterans.AddAsync(newVet);
                    await _context.SaveChangesAsync();

                    var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    var callbackUrl = Url.EmailConfirmationLink(user.Id, code, Request.Scheme);
                    await _emailSender.SendEmailConfirmationAsync(model.Email, callbackUrl);

                    await _signInManager.SignInAsync(user, isPersistent: false);
                    _logger.LogInformation("User created a new account with password.");
                    return RedirectToAction(nameof(Index));
                }
                AddErrors(result);
            }

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