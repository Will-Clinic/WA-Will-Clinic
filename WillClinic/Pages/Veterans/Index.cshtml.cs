using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WillClinic.Models;
using WillClinic.Models.Interfaces;
using WillClinic.Services;

namespace WillClinic.Pages.Veterans
{
    [Authorize(Roles = ApplicationRoles.Veteran)]
    public class IndexModel : PageModel
    {
        private readonly IVeteranService _veteranService;
        private readonly ILibraryService _libraryService;
        private readonly IMatchService _matchService;

        public IEnumerable<Library> Libraries { get; set; }

        public VeteranLawyerMatch Match { get; set; }
        public IndexModel(IVeteranService veteranService, ILibraryService libraryService, IMatchService matchService)
        {
            _veteranService = veteranService;
            _libraryService = libraryService;
            _matchService = matchService;
        }

        /// <summary>
        /// Displays the veteran's profile with options to select libraries or start their intake form
        /// </summary>
        public async Task OnGetAsync()
        {
            Veteran veteran = await _veteranService.GetVeteranByPrincipalAsync(User);
            Libraries = await _libraryService.GetAllLibrariesForVeteranAsync(veteran.ApplicationUserId);
            Match = await _matchService.GetMatchAsync();
        }
    }
}