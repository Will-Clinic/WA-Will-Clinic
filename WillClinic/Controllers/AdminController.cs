using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WillClinic.Data;
using WillClinic.Models;

namespace WillClinic.Controllers
{
    public class AdminController : Controller
    {
        readonly ApplicationDbContext _context;

        public AdminController(ApplicationDbContext ctx)
        {
            _context = ctx;
        }
        
        public IActionResult Index()
        {   
            // capturing the list of lawyers who are not yet verified
            var results = _context.Lawyers.Include(x => x.ApplicationUser).Where(x => x.IsVerified == false).Where(x => x.IsRejected != true).ToList();

            // Displaying above list to the View
            return View(results);            
        }

        /// <summary>
        /// This method is for verifying lawyers and updateing their status
        /// </summary>
        /// <param name="id">Attorney's Application User ID</param>
        /// <returns>Attorney.isVerified = true; || Returns nothing if ID is not a match.</returns>
        public IActionResult VerifyLawyer(string id)
        {
            var attorney = _context.Lawyers.First(x => x.ApplicationUserId == id);

            //If attorney ID is found and valid, change verified status
            if (attorney.ApplicationUserId == id)
            {
                attorney.IsVerified = true;
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            //If ID is not a match, rerender index page and make no changes
            else
            {
                return RedirectToAction("Index");
            }
        }

        /// <summary>
        /// Method removes lawyer from queue if they cannot be verified or can no longer practice law.
        /// </summary>
        /// <param name="id">Lawyer Application ID</param>
        /// <returns>If lawyer is found by ID, attorney.IsRejected is changed to true || no change is made if lawyer object is not valid.</returns>
        public IActionResult RemoveLawyer(string id)
        {
            var attorney = _context.Lawyers.First(x => x.ApplicationUserId == id);
            if (attorney != null)
            {
                attorney.IsRejected = true;
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }
    }
}