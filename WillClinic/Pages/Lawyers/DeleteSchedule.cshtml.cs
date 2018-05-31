using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WillClinic.Models;
using WillClinic.Services;

namespace WillClinic.Pages.Lawyers
{
    [Authorize(Roles = ApplicationRoles.Lawyer)]
    public class DeleteScheduleModel : PageModel
    {
        private readonly ILawyerService _lawyerService;

        public LawyerSchedule LawyerSchedule { get; set; }

        public DeleteScheduleModel(ILawyerService lawyerService)
        {
            _lawyerService = lawyerService;
        }

        /// <summary>
        /// Displays a confirmation page to determine whether the user really wants to delete the specified schedule
        /// </summary>
        /// <param name="id">The primary key for the LawyerSchedule entity to delete</param>
        /// <returns>PageResult if the signed in user owns the schedule and the schedule exists. HTTP 404 otherwise</returns>
        public async Task<IActionResult> OnGetAsync(long? id)
        {
            // Make sure the logged in user actually owns the specified schedule. If so, return PageResult
            if (id.HasValue)
            {
                Lawyer lawyer = await _lawyerService.GetLawyerByPrincipalAsync(User);
                LawyerSchedule = lawyer.LawyerSchedules.FirstOrDefault(ls => ls.ID == id.Value);

                if (LawyerSchedule != null)
                {
                    return Page();
                }
            }

            // Either the schedule couldn't be found or it wasn't owned by the signed in user. Return HTTP 404
            return NotFound();
        }

        /// <summary>
        /// The user has confirmed they would like to delete the specified schedule. Delete it.
        /// </summary>
        /// <param name="id">The primary key for the LawyerSchedule entity to delete</param>
        /// <returns>RedirectToPageResult to Index upon successful deletion. HTTP 404 is returned if the
        /// signed in user does not own the schedule or the schedule couldn't be found. Returns HTTP 500
        /// if a database error occurred.</returns>
        public async Task<IActionResult> OnPostAsync(long? id)
        {
            if (id.HasValue)
            {
                Lawyer lawyer = await _lawyerService.GetLawyerByPrincipalAsync(User);
                LawyerSchedule = lawyer.LawyerSchedules.FirstOrDefault(ls => ls.ID == id.Value);

                if (LawyerSchedule != null)
                {
                    // The provided id checks out; attempt to delete the schedule
                    if (await _lawyerService.DeleteScheduleAsync(LawyerSchedule))
                    {
                        return RedirectToPage("Index");
                    }

                    // A database error has occurred; return 500 to indicate database error
                    return StatusCode(StatusCodes.Status500InternalServerError);
                }
            }

            // The schedule could not be found or it did not belong to the signed in user
            return NotFound();
        }
    }
}