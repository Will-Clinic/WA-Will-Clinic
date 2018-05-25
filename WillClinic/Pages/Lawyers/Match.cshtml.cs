using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WillClinic.Models;
using WillClinic.Services;

namespace WillClinic.Pages.Lawyers
{
    [Authorize(Roles = ApplicationRoles.Lawyer)]
    public class MatchModel : PageModel
    {
        private readonly IVeteranService _veteranService;
        private readonly ILawyerService _lawyerService;

        public Veteran Veteran { get; set; }
        public IEnumerable<VeteranLibraryJunction> VeteranLibraryJunctions { get; set; }

        public MatchModel(IVeteranService veteranService, ILawyerService lawyerService)
        {
            _veteranService = veteranService;
            _lawyerService = lawyerService;
        }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            Veteran = await _veteranService.FindVeteranAsync(id);
            VeteranLibraryJunctions = await _veteranService.GetVeteranLibraryJunctionsAsync(id);

            if (Veteran is null)
            {
                return NotFound();
            }

            return Page();
        }

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
            return RedirectToPage("Index");
        }
    }
}