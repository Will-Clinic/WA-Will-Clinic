using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WillClinic.Models;
using WillClinic.Services;

namespace WillClinic.Pages.Veterans
{
    public class IndexModel : PageModel
    {
        private readonly IVeteranService _veteranService;
        private readonly ILibraryService _libraryService;

        public IEnumerable<Library> Libraries { get; set; }

        public IndexModel(IVeteranService veteranService, ILibraryService libraryService)
        {
            _veteranService = veteranService;
            _libraryService = libraryService;
        }

        public async Task OnGetAsync()
        {
            Veteran veteran = await _veteranService.GetVeteranByPrincipalAsync(User);
            Libraries = await _libraryService.GetAllLibrariesForVeteranAsync(veteran.ApplicationUserId);
        }
    }
}