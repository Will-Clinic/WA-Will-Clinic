using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WillClinic.Models;
using WillClinic.Services;

namespace WillClinic.Pages.Lawyers
{
    public class ScheduleModel : PageModel
    {
        private readonly ILibraryService _libraryService;
        private readonly ILawyerService _lawyerService;

        [BindProperty]
        public long? ScheduleId { get; set; }
        [BindProperty]
        [DataType(DataType.Time)]
        [Display(Name = "Beginning Time")]
        public TimeSpan TimeBegin { get; set; }
        [BindProperty]
        [DataType(DataType.Time)]
        [Display(Name = "Ending Time")]
        public TimeSpan TimeEnd { get; set; }
        [BindProperty]
        public bool IsRecurring { get; set; }
        [BindProperty]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
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

        public ScheduleModel(ILibraryService libraryService, ILawyerService lawyerService)
        {
            _libraryService = libraryService;
            _lawyerService = lawyerService;
        }

        public async Task OnGetAsync(long? id)
        {
            if (id.HasValue)
            {
                Lawyer lawyer = await _lawyerService.GetLawyerByPrincipalAsync(User);
                LawyerSchedule schedule = lawyer.LawyerSchedules.FirstOrDefault(ls => ls.ID == id.Value);

                ScheduleId = id;

                TimeBegin = schedule.TimeBegin.TimeOfDay;
                TimeEnd = schedule.TimeEnd.TimeOfDay;
                Date = schedule.TimeBegin.Date;

                if (schedule.RecurringDays != RecurringDays.None)
                {
                    IsRecurring = true;
                    Sunday = (schedule.RecurringDays & RecurringDays.Sunday) > 0;
                    Monday = (schedule.RecurringDays & RecurringDays.Monday) > 0;
                    Tuesday = (schedule.RecurringDays & RecurringDays.Tuesday) > 0;
                    Wednesday = (schedule.RecurringDays & RecurringDays.Wednesday) > 0;
                    Thursday = (schedule.RecurringDays & RecurringDays.Thursday) > 0;
                    Friday = (schedule.RecurringDays & RecurringDays.Friday) > 0;
                    Saturday = (schedule.RecurringDays & RecurringDays.Saturday) > 0;
                }
            }
            else
            {
                Date = DateTime.Today;
            }
        }

        public async Task<IActionResult> OnPostAsync(long? id)
        {
            Lawyer lawyer = await _lawyerService.GetLawyerByPrincipalAsync(User);
            LawyerSchedule schedule;

            if (id.HasValue)
            {
                schedule = lawyer.LawyerSchedules.FirstOrDefault(ls => ls.ID == id.Value);

                // Prevent any fraudulent edits to schedules the lawyer does not own
                if (schedule is null)
                {
                    return StatusCode(StatusCodes.Status403Forbidden);
                }
            }
            else
            {
                schedule = new LawyerSchedule();
            }

            schedule.LawyerId = lawyer.ApplicationUserId;
            
            if (IsRecurring)
            {
                schedule.TimeBegin = DateTime.UtcNow.Add(TimeBegin);
                schedule.TimeEnd = DateTime.UtcNow.Add(TimeEnd);

                // Construct RecurringDays based on checkbox input
                schedule.RecurringDays =
                    (Sunday ? RecurringDays.Sunday : RecurringDays.None) |
                    (Monday ? RecurringDays.Monday : RecurringDays.None) |
                    (Tuesday ? RecurringDays.Tuesday : RecurringDays.None) |
                    (Wednesday ? RecurringDays.Wednesday : RecurringDays.None) |
                    (Thursday ? RecurringDays.Thursday : RecurringDays.None) |
                    (Friday ? RecurringDays.Friday : RecurringDays.None) |
                    (Saturday ? RecurringDays.Saturday : RecurringDays.None);
            }
            else
            {
                schedule.TimeBegin = Date.Add(TimeBegin);
                schedule.TimeEnd = Date.Add(TimeEnd);
                schedule.RecurringDays = RecurringDays.None;
            }

            if (id.HasValue)
            {
                if (await _lawyerService.UpdateScheduleAsync(schedule))
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
                if (await _lawyerService.AddScheduleAsync(schedule))
                {
                    return RedirectToPage("/Lawyers/Profile");
                }
                else
                {
                    return Page();
                }
            }
        }
    }
}