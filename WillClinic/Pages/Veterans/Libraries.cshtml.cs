using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using WillClinic.Models;
using WillClinic.Services;

namespace WillClinic.Pages.Veterans
{
    public class LibrariesModel : PageModel
    {
        private readonly ILibraryService _libraryService;
        private readonly ILawyerService _lawyerService;
        private readonly IVeteranService _veteranService;

        public SelectList AllLibraries { get; set; }

        [BindProperty]
        public List<long> SelectedLibraries { get; set; }

        public LibrariesModel(ILibraryService libraryService, ILawyerService lawyerService,
            IVeteranService veteranService)
        {
            _libraryService = libraryService;
            _lawyerService = lawyerService;
            _veteranService = veteranService;
        }

        public async Task OnGetAsync()
        {
            AllLibraries = new SelectList(_libraryService.GetAllLibraries(), "ID", "Name");
            Veteran veteran = await _veteranService.GetVeteranByPrincipalAsync(User);

            SelectedLibraries = veteran.VeteranLibraryJunctions.Select(vlj => vlj.LibraryId)
                                                               .Take(3)
                                                               .ToList();

            // Make sure there are three elements in the list
            while (SelectedLibraries.Count < 3)
            {
                SelectedLibraries.Add(long.Parse(AllLibraries.First().Value));
            }
        }

        public async Task<IActionResult> OnPostAsync()
        {
            Veteran veteran = await _veteranService.GetVeteranByPrincipalAsync(User);

            if (!ModelState.IsValid || !(await _veteranService.MergeLibraryListWithVeteranAsync(
                veteran.ApplicationUserId, SelectedLibraries)))
            {
                return Page();
            }

            return RedirectToPage("Index");
        }
    }
}