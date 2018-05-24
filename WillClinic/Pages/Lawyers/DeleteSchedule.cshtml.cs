using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WillClinic.Models;
using WillClinic.Services;

namespace WillClinic.Pages.Lawyers
{
    public class DeleteScheduleModel : PageModel
    {
        private readonly ILawyerService _lawyerService;

        public LawyerSchedule LawyerSchedule { get; set; }

        public DeleteScheduleModel(ILawyerService lawyerService)
        {
            _lawyerService = lawyerService;
        }

        public async Task<IActionResult> OnGetAsync(long? id)
        {
            if (id.HasValue)
            {
                Lawyer lawyer = await _lawyerService.GetLawyerByPrincipalAsync(User);
                LawyerSchedule = lawyer.LawyerSchedules.FirstOrDefault(ls => ls.ID == id.Value);

                if (LawyerSchedule != null)
                {
                    return Page();
                }
            }

            return NotFound();
        }

        public async Task<IActionResult> OnPostAsync(long? id)
        {
            if (id.HasValue)
            {
                Lawyer lawyer = await _lawyerService.GetLawyerByPrincipalAsync(User);
                LawyerSchedule = lawyer.LawyerSchedules.FirstOrDefault(ls => ls.ID == id.Value);

                if (LawyerSchedule != null)
                {
                    if (await _lawyerService.DeleteScheduleAsync(LawyerSchedule))
                    {
                        return RedirectToPage("Index");
                    }
                }
            }

            return NotFound();
        }
    }
}