using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using WillClinic.Models;
using WillClinic.Services;

namespace WillClinic.Pages.Lawyers
{
    // TODO(taylorjoshuaw): Add custom validators for conditionally
    //                      recurring validation rules

    // TODO(taylorjoshuaw): Change to policy?
    [Authorize(Roles = ApplicationRoles.Lawyer)]
    public class AvailabilityModel : PageModel
    {
        ILibraryService _libraryService { get; set; }
        ILawyerService _lawyerService { get; set; }

        [BindProperty]
        public LawyerAvailability LawyerAvailability { get; set; }
        [BindProperty]
        public MultiSelectList Libraries { get; set; }
        [BindProperty]
        [Required]
        [Display(Name = "Location")]
        public List<int> LibraryIds { get; set; }
        [BindProperty]
        [Display(Name = "Recurring Weekly?")]
        public bool IsRecurring { get; set; }
        [BindProperty]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
        [BindProperty]
        [DataType(DataType.Time)]
        [Display(Name = "Starting Time")]
        public DateTime TimeStart { get; set; }
        [BindProperty]
        [DataType(DataType.Time)]
        [Display(Name = "Ending Time")]
        public DateTime TimeEnd { get; set; }
        /*
        [Display(Name = "Recurring Days")]
        public MultiSelectList RecurringDaysList { get; set; }
        */

        [BindProperty]
        [Display(Name = "Recurring Days")]
        public List<string> RecurringDays { get; set; }
        [BindProperty]
        public MultiSelectList DaysOfTheWeek { get; set; }

        public AvailabilityModel(ILibraryService libraryService, ILawyerService lawyerService)
        {
            _libraryService = libraryService;
            _lawyerService = lawyerService;
        }

        public async Task OnGetAsync(int? id)
        {
            Libraries = new MultiSelectList(_libraryService.GetAllLibraries(), "ID", "Name");
            Date = DateTime.UtcNow;

            DaysOfTheWeek = new MultiSelectList(Enum.GetNames(typeof(DayOfWeek)));

            // If an ID has been provided, only retrieve that availability if it belongs to its owner
            if (id.HasValue)
            {
                Lawyer currentLawyer = await _lawyerService.GetLawyerByPrincipalAsync(User);
                var availabilities = await _lawyerService.GetLawyerAvailabilitiesAsync(currentLawyer);
                LawyerAvailability = availabilities.FirstOrDefault(a => a.ID == id.Value);
            }
        }
    }
}