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
    public class IndexModel : PageModel
    {
        private readonly ILawyerService _lawyerService;
        private readonly ILibraryService _libraryService;
        private readonly IVeteranService _veteranService;

        public Lawyer Lawyer { get; set; }
        //public ICollection<LawyerAvailability> Availabilities { get; set; }
        public IEnumerable<LawyerSchedule> Schedules { get; set; }
        public IEnumerable<Library> Libraries { get; set; }
        public TimeZoneInfo UserTimeZone { get; set; }

        public IEnumerable<Veteran> PotentialClients { get; set; }

        public IndexModel(ILawyerService lawyerService, ILibraryService libraryService,
            IVeteranService veteranService)
        {
            _lawyerService = lawyerService;
            _libraryService = libraryService;
            _veteranService = veteranService;
        }

        /// <summary>
        /// Present the lawyer with their potential clients, library choices, schedules, and options to match
        /// with potential clients, change their libraries, and to modify their schedule.
        /// </summary>
        public async Task OnGetAsync()
        {
            Lawyer = await _lawyerService.GetLawyerByPrincipalAsync(User);
            Libraries = await _libraryService.GetAllLibrariesForLawyerAsync(Lawyer.ApplicationUserId);
            Schedules = await _lawyerService.GetSchedulesAsync(Lawyer.ApplicationUserId);
            PotentialClients = await _veteranService.GetPotentialClientsForLawyerAsync(Lawyer.ApplicationUserId);

            // TODO(taylorjoshuaw): Collect time zone from user rather than assuming Pacific time
            UserTimeZone = TimeZoneInfo.FindSystemTimeZoneById("Pacific Standard Time");
        }
    }
}