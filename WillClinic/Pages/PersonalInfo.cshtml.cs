//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Mvc.RazorPages;
//using Microsoft.EntityFrameworkCore;
//using WillClinic.Data;
//using WillClinic.Models;
//using WillClinic.Models.Services;

//namespace WillClinic.Pages
//{
//    public class PersonalInfoModel : PageModel
//    {
//        public int Id { get; set; }

//        public Veteran Veteran { get; set; }

//        internal IVeteranService VeteranService { get; set; }

//        [BindProperty]
//        public string FullLegalName { get; set; }

//        [BindProperty]
//        public string Address { get; set; }

//        [BindProperty]
//        public string PhoneNumber { get; set; }

//        [BindProperty]
//        public string Email { get; set; }

//        [BindProperty]
//        public bool VeteranStatus { get; set; }

//        [BindProperty]
//        public bool ProofOfService { get; set; }

//        [BindProperty]
//        public bool ResidentStatus { get; set; }

//        [BindProperty]
//        public bool Married { get; set; }

//        [TempData]
//        public string Message { get; set; }

//        public PersonalInfoModel(IVeteranService vs)
//        {
//            VeteranService = vs;
//        }

//        public async Task<IActionResult> OnGet(int id)
//        {
//            Veteran = await VeteranService.FindAsync(id);

//            if(Veteran == null)
//            {
//                return RedirectToPage("Index");
//            }

//            return Page();
//        }

//        public async Task<IActionResult> OnPost(int id)
//        {
//            if (!ModelState.IsValid)
//            {
//                return Page();
//            }

//            Veteran veteran = await VeteranService.FindAsync(id);
//            veteran.PrimaryData.FullLegalName = Veteran.PrimaryData.FullLegalName;
//            veteran.PrimaryData.Address = Veteran.PrimaryData.Address;
//            veteran.PrimaryData.PhoneNumber = Veteran.PrimaryData.PhoneNumber;
//            veteran.PrimaryData.Email = Veteran.PrimaryData.Email;
//            veteran.PrimaryData.VeteranStatus = Veteran.PrimaryData.VeteranStatus;
//            veteran.PrimaryData.ProofOfService = Veteran.PrimaryData.ProofOfService;
//            veteran.PrimaryData.ResidentStatus = Veteran.PrimaryData.ResidentStatus;
//            veteran.PrimaryData.NetWorth = Veteran.PrimaryData.NetWorth;
//            try
//            {
//                await VeteranService.SaveAsync(veteran);
//            }
//            catch (DbUpdateConcurrencyException)
//            {
//                Message = "Profile not found";
//            }

//            return RedirectToPage("Index");
//        }
//    }
//}