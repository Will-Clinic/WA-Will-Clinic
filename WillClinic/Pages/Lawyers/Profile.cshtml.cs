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
    // TODO(taylorjoshuaw): Change to policy?
    [Authorize(Roles = ApplicationRoles.Lawyer)]
    public class ProfileModel : PageModel
    {
        private readonly ILawyerService _lawyerService;
        public Lawyer Lawyer { get; set; }
        public ICollection<LawyerAvailability> Availabilities { get; set; }

        public ProfileModel(ILawyerService lawyerService)
        {
            _lawyerService = lawyerService;
        }

        public async Task OnGetAsync()
        {
            Lawyer = await _lawyerService.GetLawyerByPrincipalAsync(User);
            Availabilities = await _lawyerService.GetLawyerAvailabilitiesAsync(Lawyer);
        }
    }
}