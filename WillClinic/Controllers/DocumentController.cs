using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Confirmation(int? id)
        {
            AllDocsViewModel vm = new AllDocsViewModel()
            {
                FirstName = "Kevin",
                MiddleName = "Alexander",
                LastName = "Farrow",
                County = "King",
                MaritalStatus = "Is married to ",
                SpouseName = "Emma Watson",
                HasChildren = true,
                Children = new List<string> { "Jack", "Kira"},
                PRPrimeFirstName = "Duncan",
                PRPrimeLastName = "Sabian",
                PRAltFirstName = "Stephanie",
                PRAltLastName = "Farrow",
                PrimeBenificiary = "Kira",
                AltBenificiary = "Jack",
                DisposeList = new List<string> { "None"},
                SuccessorPrime = "Kira",
                SuccessorAlt = "Jack"
            };

            return View(vm);
        }
    }
}
