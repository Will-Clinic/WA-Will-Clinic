using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DinkToPdf;
using DinkToPdf.Contracts;
using Microsoft.AspNetCore.Mvc;
using WillClinic.Data;
using WillClinic.Models.Documents;

namespace WillClinic.Controllers
{
    public class DocumentController : Controller
    {
        private ApplicationDbContext _context;

        public DocumentController(ApplicationDbContext context)
        {
            _context = context;
        }

        // TODO Create and index action that lists all previous documents
        public IActionResult Index()
        {
            return View();
        }

        // TODO Create an Edit Action that allows Lawyers to make changes to the documents 

        /// <summary>
        /// Action to display the populated documents for confirmation.
        /// </summary>
        /// <param name="id">Veteran ID</param>
        /// <returns>Returns a populated AllDocs View Model that will render into a legal document</returns>
        [HttpGet]
        public async Task<IActionResult> Confirmation(int? id)
        {
            //This is a hard coded view model. Production will use linq quires to populate the model based on the Veteran ID
            AllDocsViewModel vm = new AllDocsViewModel()
            {
                FirstName = "Josh",
                MiddleName = "Alexander",
                LastName = "Lymen",
                County = "King",
                MaritalStatus = "Is married to ",
                SpouseName = "Emma Lymen",
                HasChildren = true,
                Children = new List<string> { " Jack ", " Kira "},
                PRPrimeFirstName = "Duncan",
                PRPrimeLastName = "Sabian",
                PRAltFirstName = "Stephanie",
                PRAltLastName = "Farrow",
                PrimeBenificiary = " Kira ",
                AltBenificiary = " Jack ",
                DisposeList = new List<string> { "None"},
                SuccessorPrime = " Kira ",
                SuccessorAlt = " Jack "
            };
            return View(vm);
        }
    }
}
