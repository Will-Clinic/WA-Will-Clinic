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

        public Lawyer Lawyer { get; set; }
        //public ICollection<LawyerAvailability> Availabilities { get; set; }
        public IEnumerable<LawyerSchedule> Schedules { get; set; }
        public IEnumerable<Library> Libraries { get; set; }
        public TimeZoneInfo UserTimeZone { get; set; }

        public IndexModel(ILawyerService lawyerService, ILibraryService libraryService)
        {
            _lawyerService = lawyerService;
            _libraryService = libraryService;
        }

        public async Task OnGetAsync()
        {
            Lawyer = await _lawyerService.GetLawyerByPrincipalAsync(User);
            Libraries = await _libraryService.GetAllLibrariesForLawyerAsync(Lawyer.ApplicationUserId);
            Schedules = await _lawyerService.GetSchedulesAsync(Lawyer.ApplicationUserId);

            // TODO(taylorjoshuaw): Collect time zone from user rather than assuming Pacific time
            UserTimeZone = TimeZoneInfo.FindSystemTimeZoneById("Pacific Standard Time");
        }
    }
}