using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using WillClinic.Models;
using WillClinic.Services;

namespace WillClinic.Pages.Veterans
{
    [Authorize(Roles = ApplicationRoles.Veteran)]
    public class LibrariesModel : PageModel
    {
        private readonly ILibraryService _libraryService;
        private readonly ILawyerService _lawyerService;
        private readonly IVeteranService _veteranService;

        /// <summary>
        /// All Library entities from the Library table
        /// </summary>
        public SelectList AllLibraries { get; set; }

        /// <summary>
        /// The library selections made on the form by the veteran
        /// </summary>
        [BindProperty]
        public List<long> SelectedLibraries { get; set; }

        public LibrariesModel(ILibraryService libraryService, ILawyerService lawyerService,
            IVeteranService veteranService)
        {
            _libraryService = libraryService;
            _lawyerService = lawyerService;
            _veteranService = veteranService;
        }

        /// <summary>
        /// Allows the veteran to choose up to 3 libraries at which to meet attorneys
        /// </summary>
        public async Task OnGetAsync()
        {
            // Populate a SelectList for the library options on the form using the Library table
            //AllLibraries = new SelectList(_libraryService.GetAllLibraries(), "ID", "Name");

            AllLibraries = new SelectList(await _libraryService.GetAllLibrariesWithLawyers(), "ID", "Name");
            
            // Get the current signed in Veteran entity
            Veteran veteran = await _veteranService.GetVeteranByPrincipalAsync(User);

            // If the veteran has already chosen some libraries, get those choices for the form via
            // the VeteranLibraryJunction table. Only take 3 choices per the client's request
            SelectedLibraries = veteran.VeteranLibraryJunctions.Select(vlj => vlj.LibraryId)
                                                               .Take(3)
                                                               .ToList();
            long libCount = AllLibraries.LongCount();
            // Make sure there are at least three elements in the list to prevent any issues with indexing
            
            while (SelectedLibraries.Count < 3 && AllLibraries.LongCount() > 0)
            {
                SelectedLibraries.Add(long.Parse(AllLibraries.First().Value));
            }
        }

        /// <summary>
        /// The veteran has chosen to save their library selection changes. Establish new relationships
        /// based on the veteran's choices and deleted newly orphaned ones via the VeteranLibraryJunction table
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> OnPostAsync()
        {
            // Get the currently signed in veteran
            Veteran veteran = await _veteranService.GetVeteranByPrincipalAsync(User);

            // Attempt to update the state of the VeteranLibraryJunction table based on the veteran's POSTed choices
            if (!ModelState.IsValid || !(await _veteranService.MergeLibraryListWithVeteranAsync(
                veteran.ApplicationUserId, SelectedLibraries)))
            {
                // The changes could not be ma/de. Display the page to the user again with validation errors (if
                // applicable) to give them another chance to commit their changes
                return Page();
            }

            // Success! Redirect to index
            return RedirectToPage("Index");
        }
    }
}