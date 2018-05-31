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

        /// <summary>
        /// All available libraries from the Library table
        /// </summary>
        public MultiSelectList AllLibraries { get; set; }

        /// <summary>
        /// The primary keys for all chosen Library entities
        /// </summary>
        [BindProperty]
        [Display(Name = "Selected Libraries for Meeting Places")]
        public IEnumerable<long> SelectedLibraryIds { get; set; }

        public LibrariesModel(ILibraryService libraryService, ILawyerService lawyerService)
        {
            _libraryService = libraryService;
            _lawyerService = lawyerService;
        }

        /// <summary>
        /// Presents the lawyer with options to define the libraries they would be willing to meet veterans at
        /// </summary>
        public async Task OnGetAsync()
        {
            Lawyer lawyer = await _lawyerService.GetLawyerByPrincipalAsync(User);
            SelectedLibraryIds = (await _libraryService.GetAllLibrariesForLawyerAsync(lawyer.ApplicationUserId)).Select(l => l.ID);
            AllLibraries = new MultiSelectList(_libraryService.GetAllLibraries(), "ID", "Name");
        }

        /// <summary>
        /// The lawyer has chosen to save their changes made on the form presented on GET. Add relationships between
        /// the lawyer to the chosen libraries via the LawyerLibraryJunction table.
        /// </summary>
        /// <returns>RedirectToPageResult for Index on successful creation of relationships between the lawyer and
        /// all selected libraries. PageResult if ModelState was invalid or if some error occurred with creating / removing
        /// rows on the LawyerLibraryJunction table to allow the user an opportunity to try again.</returns>
        public async Task<IActionResult> OnPostAsync()
        {
            Lawyer lawyer = await _lawyerService.GetLawyerByPrincipalAsync(User);

            // Try to merge the state of Lawyer <-> Library relationships
            if (!ModelState.IsValid || !(await _lawyerService.MergeLibraryListWithLawyerAsync(
                lawyer.ApplicationUserId, SelectedLibraryIds)))
            {
                // Something went wrong; give the user another opportunity to modify their libraries
                return Page();
            }

            // Success! Redirect to index
            return RedirectToPage("Index");
        }
    }
}