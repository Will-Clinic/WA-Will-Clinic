using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using WillClinic.Models;
using WillClinic.Services;

namespace WillClinic.Pages.Lawyers
{
    [Authorize(Roles = ApplicationRoles.Lawyer)]
    public class MatchModel : PageModel
    {
        private readonly IVeteranService _veteranService;
        private readonly ILawyerService _lawyerService;
        private readonly ILogger<MatchModel> _logger;

        public Veteran Veteran { get; set; }
        public IEnumerable<VeteranLibraryJunction> VeteranLibraryJunctions { get; set; }

        public MatchModel(IVeteranService veteranService, ILawyerService lawyerService, ILogger<MatchModel> logger)
        {
            _veteranService = veteranService;
            _lawyerService = lawyerService;
            _logger = logger;
        }

        /// <summary>
        /// Present the lawyer with alternative meeting locations and confirm the initiation of the matching process
        /// </summary>
        /// <param name="id">The primary key of the Veteran entity to match with</param>
        /// <returns>PageResult if the specified veteran was found; otherwise HTTP 404</returns>
        public async Task<IActionResult> OnGetAsync(string id)
        {
            // Get the specified veteran
            Veteran = await _veteranService.FindVeteranAsync(id);
            // Get the veteran's other chosen meeting locations
            VeteranLibraryJunctions = await _veteranService.GetVeteranLibraryJunctionsAsync(id);

            // Make sure the specified veteran exists
            if (Veteran is null)
            {
                return NotFound();
            }

            // TODO(taylorjoshuaw): Add verification here to make sure that the specified veteran is indeed
            //                      available to match with the lawyer

            // Success!
            return Page();
        }

        /// <summary>
        /// The lawyer has confirmed they would like to initiate the matching process with the specified
        /// veteran. Add a new VeteranLawyerMatch row to the database to get the process started pending
        /// veteran approval.
        /// </summary>
        /// <param name="id">The primary key for the Veteran entity to match with</param>
        /// <returns>RedirectToPageResult to Index</returns>
        public async Task<IActionResult> OnPostAsync(string id)
        {
            Lawyer lawyer = await _lawyerService.GetLawyerByPrincipalAsync(User);

            if (await _lawyerService.MatchWithVeteranAsync(lawyer.ApplicationUserId, id))
            {
                // TODO(taylorjoshuaw): The next steps of matching would take place at this
                //                      point. This could be e-mail, a built-in agreement
                //                      system to coordinate location / time, etc.
                return RedirectToPage("Index");
            }

            // Something went wrong, send the user back to Index. This could use a message
            // to clarify the situation to the user, but TempData </3 Azure.
            _logger.LogError($"An error occurred while attempted to match Lawyer id: {lawyer.ApplicationUserId} with Veteran id: {id}");
            return RedirectToPage("Index");
        }
    }
}