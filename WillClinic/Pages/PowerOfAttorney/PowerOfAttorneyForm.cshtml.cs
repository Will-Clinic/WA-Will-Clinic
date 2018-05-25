using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WillClinic.Models;
using WillClinic.Models.Services;
using WillClinic.Models.VeteranModels;

namespace WillClinic.Pages.PowerOfAttorneyForm
{
    public class PowerOfAttorneyFormModel : PageModel
    {
        public int Id { get; set; }
        public Veteran Veteran { get; set; }
        internal IVeteranService VeteranService { get; set; }


        [BindProperty]
        public PowerOfAttorney PowerOfAttorney { get; set; }

        [TempData]
        public string Message { get; set; }

        public PowerOfAttorneyFormModel(IVeteranService vs)
        {
            VeteranService = vs;
        }

        public async Task<IActionResult> OnGet(int id)
        {
            Veteran = await VeteranService.FindAsync(id);

            if (Veteran == null)
            {
                return RedirectToPage("Index");
            }

            return Page();
        }

        //public async Task<IActionResult> OnPost(int id)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return Page();
        //    }

        //    Veteran veteran = await VeteranService.FindAsync(id);
            
        //}
    }
}