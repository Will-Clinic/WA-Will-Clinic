using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WillClinic.Data;
using WillClinic.Models;

namespace WillClinic.Controllers
{
    public class LawyersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public LawyersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Lawyers
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Lawyer_1.Include(l => l.ApplicationUser);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Lawyers/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lawyer = await _context.Lawyer_1
                .Include(l => l.ApplicationUser)
                .SingleOrDefaultAsync(m => m.ApplicationUserId == id);
            if (lawyer == null)
            {
                return NotFound();
            }

            return View(lawyer);
        }

        // GET: Lawyers/Create
        public IActionResult Create()
        {
            ViewData["ApplicationUserId"] = new SelectList(_context.Users, "Id", "Id");
            return View();
        }

        // POST: Lawyers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ApplicationUserId,BarNumber,DOB,City,Country,State,ZipCode,Password,ConfirmPassword,PracticeAreas,OtherLanguages")] Lawyer lawyer)
        {
            if (ModelState.IsValid)
            {
                _context.Add(lawyer);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ApplicationUserId"] = new SelectList(_context.Users, "Id", "Id", lawyer.ApplicationUserId);
            return View(lawyer);
        }

        // GET: Lawyers/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lawyer = await _context.Lawyer_1.SingleOrDefaultAsync(m => m.ApplicationUserId == id);
            if (lawyer == null)
            {
                return NotFound();
            }
            ViewData["ApplicationUserId"] = new SelectList(_context.Users, "Id", "Id", lawyer.ApplicationUserId);
            return View(lawyer);
        }

        // POST: Lawyers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("ApplicationUserId,BarNumber,DOB,City,Country,State,ZipCode,Password,ConfirmPassword,PracticeAreas,OtherLanguages")] Lawyer lawyer)
        {
            if (id != lawyer.ApplicationUserId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(lawyer);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LawyerExists(lawyer.ApplicationUserId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["ApplicationUserId"] = new SelectList(_context.Users, "Id", "Id", lawyer.ApplicationUserId);
            return View(lawyer);
        }

        // GET: Lawyers/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lawyer = await _context.Lawyer_1
                .Include(l => l.ApplicationUser)
                .SingleOrDefaultAsync(m => m.ApplicationUserId == id);
            if (lawyer == null)
            {
                return NotFound();
            }

            return View(lawyer);
        }

        // POST: Lawyers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var lawyer = await _context.Lawyer_1.SingleOrDefaultAsync(m => m.ApplicationUserId == id);
            _context.Lawyer_1.Remove(lawyer);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LawyerExists(string id)
        {
            return _context.Lawyer_1.Any(e => e.ApplicationUserId == id);
        }
    }
}
