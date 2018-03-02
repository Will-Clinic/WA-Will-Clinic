using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using WillClinic.Data;
using WillClinic.Models;
using WillClinic.Models.AccountViewModels;
using WillClinic.Services;

namespace WillClinic.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ApplicationDbContext _context;
        private readonly IEmailSender _emailSender;
        private readonly ILogger _logger;

        public AdminController(
            RoleManager<IdentityRole> roleManager,
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            ApplicationDbContext context,
            IEmailSender emailSender,
            ILogger<LawyerController> logger)
        {
            _roleManager = roleManager;
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;
            _emailSender = emailSender;
            _logger = logger;
        }
        public IActionResult Index()
        {   
            // capturing the list of lawyers who are not yet verified
            var results = _context.Lawyers.Include(x => x.ApplicationUser).Where(x => x.IsVerified == false).Where(x => x.IsRejected != true).ToList();

            // Displaying above list to the View
            return View(results);            
        }

        public IActionResult RejectedLawyers()
        {
            var results = _context.Lawyers.Include(x => x.ApplicationUser).Where(x => x.IsRejected == true);

            return View(results);
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
        public async Task<IActionResult> Register(RegisterAdminViewModel model, string returnUrl = null)
        {
            //CHeck if admin role exists
            if(!await _roleManager.RoleExistsAsync("Admin"))
            {
                await _roleManager.CreateAsync(new IdentityRole("Admin"));
            }
           

            ViewData["ReturnUrl"] = returnUrl;
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser { UserName = model.Email, Email = model.Email, FirstName = model.FirstName, MiddleInitial = model.MiddleInitial, LastName = model.LastName };
                var result = await _userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    _logger.LogInformation("User created a new account with password.");

                    // Setting up claims for the Admin
                    string fullname = $"{model.FirstName} {model.MiddleInitial}. {model.LastName}";
                    Claim name = new Claim(ClaimTypes.Name, fullname, ClaimValueTypes.String);
                    Claim email = new Claim(ClaimTypes.Email, model.Email, ClaimValueTypes.String);
                    List<Claim> claims = new List<Claim> { name, email };
                    await _userManager.AddClaimsAsync(user, claims);

                    // Adding Role to Admin account
                    await _userManager.AddToRoleAsync(user, ApplicationRoles.Admin);

                    // Populate Admin Table with new account
                    Admin newAdmin = new Admin { ApplicationUserId = user.Id};
                    await _context.Admins.AddAsync(newAdmin);
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
    



/// <summary>
/// This method is for verifying lawyers and updateing their status
/// </summary>
/// <param name="id">Attorney's Application User ID</param>
/// <returns>Attorney.isVerified = true; || Returns nothing if ID is not a match.</returns>
public IActionResult VerifyLawyer(string id)
        {
            var attorney = _context.Lawyers.First(x => x.ApplicationUserId == id);

            //If attorney ID is found and valid, change verified status
            if (attorney.ApplicationUserId == id)
            {
                attorney.IsVerified = true;
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            //If ID is not a match, rerender index page and make no changes
            else
            {
                return RedirectToAction("Index");
            }
        }

        /// <summary>
        /// Method removes lawyer from queue if they cannot be verified or can no longer practice law.
        /// </summary>
        /// <param name="id">Lawyer Application ID</param>
        /// <returns>If lawyer is found by ID, attorney.IsRejected is changed to true || no change is made if lawyer object is not valid.</returns>
        public IActionResult RemoveLawyer(string id)
        {
            var attorney = _context.Lawyers.First(x => x.ApplicationUserId == id);
            if (attorney != null)
            {
                attorney.IsRejected = true;
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }
    }

}
