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
    // TODO(taylorjoshuaw): Change to policy?
    [Authorize(Roles = ApplicationRoles.Lawyer)]
    public class AvailabilityModel : PageModel
    {
        ILibraryService _libraryService { get; set; }
        ILawyerService _lawyerService { get; set; }

        [BindProperty]
        public LawyerAvailability LawyerAvailability { get; set; }
        [BindProperty]
        public SelectList Libraries { get; set; }
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
        [BindProperty]
        public bool Sunday { get; set; }
        [BindProperty]
        public bool Monday { get; set; }
        [BindProperty]
        public bool Tuesday { get; set; }
        [BindProperty]
        public bool Wednesday { get; set; }
        [BindProperty]
        public bool Thursday { get; set; }
        [BindProperty]
        public bool Friday { get; set; }
        [BindProperty]
        public bool Saturday { get; set; }

        public AvailabilityModel(ILibraryService libraryService, ILawyerService lawyerService)
        {
            _libraryService = libraryService;
            _lawyerService = lawyerService;
        }

        public async Task OnGetAsync(int? id)
        {
            Libraries = new SelectList(_libraryService.GetAllLibraries(), "ID", "Name");

            // If an ID has been provided, only retrieve that available if it belongs to its owner
            if (id.HasValue)
            {
                Lawyer currentLawyer = await _lawyerService.GetLawyerByPrincipalAsync(User);
                var availabilities = await _lawyerService.GetLawyerAvailabilitiesAsync(currentLawyer);
                LawyerAvailability = availabilities.FirstOrDefault(a => a.ID == id.Value);
            }
        }
    }
}