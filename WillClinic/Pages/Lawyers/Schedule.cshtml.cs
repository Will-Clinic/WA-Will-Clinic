using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
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
                var schedule = lawyer.LawyerSchedules.FirstOrDefault(ls => ls.ID == id.Value);

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
    }
}