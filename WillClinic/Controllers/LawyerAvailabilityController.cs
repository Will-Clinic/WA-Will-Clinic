using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WillClinic.Data;
using WillClinic.Models;

namespace WillClinic.Controllers
{
    public class LawyerAvailabilityController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public LawyerAvailabilityController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, ApplicationDbContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;
        }

        // GET: LawyerAvailability
        //public async Task<IActionResult> Index()
        //{
        //    var applicationDbContext = _context.LawyerAvailability.Include(l => l.Lawyer);
        //    return View(await applicationDbContext.ToListAsync());
        //}

        // GET: LawyerAvailability/Details/5
        //public async Task<IActionResult> Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var lawyerAvailability = await _context.LawyerAvailability
        //        .Include(l => l.Lawyer)
        //        .SingleOrDefaultAsync(m => m.ID == id);
        //    if (lawyerAvailability == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(lawyerAvailability);
        //}

        //// GET: LawyerAvailability/Create
        public IActionResult Create()
        {
            ViewData["LawyerId"] = new SelectList(_context.Lawyers, "ApplicationUserId", "ApplicationUserId");
            return View();
        }

        // POST: LawyerAvailability/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TimeAvailable")] LawyerAvailability lawyerAvailability)
        {
            if (ModelState.IsValid)
            {
                lawyerAvailability.LawyerId = _userManager.GetUserId(User);
                _context.Add(lawyerAvailability);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(LawyerController.Index), "Lawyer");
            }
            ViewData["LawyerId"] = new SelectList(_context.Lawyers, "ApplicationUserId", "ApplicationUserId", lawyerAvailability.LawyerId);

            return RedirectToAction(nameof(LawyerController.Index), "Lawyer");
        }

        // GET: LawyerAvailability/Edit/5
        //public async Task<IActionResult> Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var lawyerAvailability = await _context.LawyerAvailability.SingleOrDefaultAsync(m => m.ID == id);
        //    if (lawyerAvailability == null)
        //    {
        //        return NotFound();
        //    }
        //    ViewData["LawyerId"] = new SelectList(_context.Lawyers, "ApplicationUserId", "ApplicationUserId", lawyerAvailability.LawyerId);
        //    return View(lawyerAvailability);
        //}

        // POST: LawyerAvailability/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, [Bind("ID,LawyerId,TimeAvailable")] LawyerAvailability lawyerAvailability)
        //{
        //    if (id != lawyerAvailability.ID)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(lawyerAvailability);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!LawyerAvailabilityExists(lawyerAvailability.ID))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }
        //        return RedirectToAction(nameof(LawyerController.Index), "Lawyer");
        //    }
        //    ViewData["LawyerId"] = new SelectList(_context.Lawyers, "ApplicationUserId", "ApplicationUserId", lawyerAvailability.LawyerId);
        //    return RedirectToAction(nameof(LawyerController.Index), "Lawyer");
        //}

        // GET: LawyerAvailability/Delete/5
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var lawyerAvailability = await _context.LawyerAvailability
        //        .Include(l => l.Lawyer)
        //        .SingleOrDefaultAsync(m => m.ID == id);
        //    if (lawyerAvailability == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(lawyerAvailability);
        //}

        // POST: LawyerAvailability/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var lawyerAvailability = await _context.LawyerAvailability.SingleOrDefaultAsync(m => m.ID == id);
            _context.LawyerAvailability.Remove(lawyerAvailability);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(LawyerController.Index), "Lawyer");
        }

        private bool LawyerAvailabilityExists(int id)
        {
            return _context.LawyerAvailability.Any(e => e.ID == id);
        }
    }
}
