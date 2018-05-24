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
    [Authorize(Roles = ApplicationRoles.Lawyer)]
    public class LibrariesModel : PageModel
    {
        private readonly ILibraryService _libraryService;
        private readonly ILawyerService _lawyerService;

        public MultiSelectList AllLibraries { get; set; }

        [BindProperty]
        [Display(Name = "Selected Libraries for Meeting Places")]
        public IEnumerable<long> SelectedLibraryIds { get; set; }

        public LibrariesModel(ILibraryService libraryService, ILawyerService lawyerService)
        {
            _libraryService = libraryService;
            _lawyerService = lawyerService;
        }

        public async Task OnGetAsync()
        {
            Lawyer lawyer = await _lawyerService.GetLawyerByPrincipalAsync(User);
            SelectedLibraryIds = (await _libraryService.GetAllLibrariesForLawyerAsync(lawyer.ApplicationUserId)).Select(l => l.ID);
            AllLibraries = new MultiSelectList(_libraryService.GetAllLibraries(), "ID", "Name");
        }

        public async Task<IActionResult> OnPostAsync()
        {
            Lawyer lawyer = await _lawyerService.GetLawyerByPrincipalAsync(User);

            if (!ModelState.IsValid || !(await _lawyerService.MergeLibraryListWithLawyerAsync(
                lawyer.ApplicationUserId, SelectedLibraryIds)))
            {
                return Page();
            }

            return RedirectToPage("Index");
        }
    }
}