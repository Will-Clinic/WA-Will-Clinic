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

        private readonly IAvailabilityService _availabilityService;

        [BindProperty]
        public int? AvailabilityId { get; set; }
        
        [BindProperty]
        [Required]
        [Display(Name = "Location")]
        public List<int> LibraryIds { get; set; }
        public MultiSelectList Libraries { get; set; }
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
        public string[] RecurringDays { get; set; }
        public MultiSelectList DaysOfTheWeek { get; set; }

        public AvailabilityModel(ILibraryService libraryService,
            ILawyerService lawyerService, IAvailabilityService availabilityService)
        {
            _libraryService = libraryService;
            _lawyerService = lawyerService;
            _availabilityService = availabilityService;
        }

        public async Task OnGetAsync(int? id)
        {
            throw new NotImplementedException();
            /*
            Libraries = new MultiSelectList(_libraryService.GetAllLibraries(), "ID", "Name");
            Date = DateTime.UtcNow;

            DaysOfTheWeek = new MultiSelectList(Enum.GetNames(typeof(DayOfWeek)));

            // If an ID has been provided, only retrieve that availability if it belongs to its owner
            if (id.HasValue)
            {
                Lawyer currentLawyer = await _lawyerService.GetLawyerByPrincipalAsync(User);
                var availabilities = await _lawyerService.GetLawyerAvailabilitiesAsync(currentLawyer);
                LawyerAvailability availability = availabilities.FirstOrDefault(a => a.ID == id.Value);
                AvailabilityId = availability.ID;
                // TODO(taylorjoshuaw): Fill in view model if the availability exists
            }
            */
        }

        [ValidateAntiForgeryToken]
        public async Task<IActionResult> OnPostAsync(int? id)
        {
            throw new NotImplementedException();
            /*
            Lawyer currentLawyer = await _lawyerService.GetLawyerByPrincipalAsync(User);
            LawyerAvailability availability;
            bool newAvailability = true;

            if (id.HasValue)
            {
                var availabilities = await _lawyerService.GetLawyerAvailabilitiesAsync(currentLawyer);
                availability = availabilities.FirstOrDefault(a => a.ID == id.Value);

                // If no availabilities for the currently logged in lawyer exist with the specified id,
                // do not proceeed (prevent the user from modifying other users' availabilities by editing
                // their HTML POST request values)
                if (availability is null)
                {
                    return NotFound();
                }

                newAvailability = false;
            }
            else
            {
                availability = new LawyerAvailability();
                availability.LibraryAvailabilityJunctions = new List<LibraryAvailabilityJunction>();
            }

            availability.LawyerId = currentLawyer.ApplicationUserId;

            foreach (int libraryId in LibraryIds)
            {
                Library library = await _libraryService.FindLibraryByIdAsync(libraryId);
                
                if (library != null)
                {
                    if (!availability.LibraryAvailabilityJunctions.Any(laj => laj.LibraryId == library.ID))
                    {
                        LibraryAvailabilityJunction junction = new LibraryAvailabilityJunction()
                        {
                            LawyerAvailabilityId = availability.ID,
                            LibraryId = library.ID
                        };

                        await _availabilityService.AddLibraryJunctionAsync(junction);
                    }
                }
            }

            if (IsRecurring)
            {
                // Combine together all the days selected into flags of the RecurringDays enum
                foreach (string day in RecurringDays)
                {
                    // HACK(taylorjoshuaw): For some reason, no matter how I feed strings into the
                    //                      MultiSelectList, the result comes back corrupted for
                    //                      Thursday and Sunday (an extra 'y' or a weird unicode character
                    //                      results from those two days). This fixes this problem for now.
                    //                      I have tried to manually construct the select list from
                    //                      SelectListItem instances, but this doesn't help.
                    string correctedDay = $"{day.Split('y')[0]}y";
                    availability.RecurringDays |= Enum.Parse<RecurringDays>(correctedDay);
                }

                availability.DateTimeBegin = TimeStart;
                availability.DateTimeEnd = TimeEnd;
            }
            else
            {
                availability.DateTimeBegin = Date.Add(TimeStart.TimeOfDay);
                availability.DateTimeEnd = Date.Add(TimeEnd.TimeOfDay);
            }

            if (newAvailability)
            {
                if (await _availabilityService.AddAsync(availability))
                {
                    return RedirectToPage("/Lawyers/Profile");
                }
                else
                {
                    return Page();
                }
            }
            else
            {
                if (await _availabilityService.UpdateAsync(availability))
                {
                    return RedirectToPage("/Lawyers/Profile");
                }
                else
                {
                    return Page();
                }
            }
            */
        }
    }
}