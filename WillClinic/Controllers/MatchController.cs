using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WillClinic.Models;
using WillClinic.Models.Interfaces;

namespace WillClinic.Controllers
{

    //Controls stuff regarding the match item between the Veteran and Lawyer which should allow access to all required data.

    public class MatchController : Controller
    {
        // See MatchService in Services folder
        private readonly IMatchService _matchService;
        private readonly UserManager<ApplicationUser> _userManager;

        public MatchController(IMatchService matchService, UserManager<ApplicationUser> userManager)
        {
            _matchService = matchService;
            _userManager = userManager;
        }

        public async Task<ActionResult> AddtoQueue()
        {
            var user = await _userManager.GetUserAsync(User);
            _matchService.AddtoQueue(user.Id);
            return RedirectToAction("Index", "Veteran");
        }

        public ActionResult FindVeteran()
        {
            // var user = await _userManager.GetUserAsync(User);
            _matchService.FindVeteran();
            return RedirectToAction("Index", "Lawyer");
        }

        public ActionResult AcceptTimeSlot(int timeId)
        {
            _matchService.AcceptTimeSlot(timeId);
            return RedirectToAction("Index", "Veteran");
        }

        public ViewResult Application(int matchId)
        {
            VeteranIntakeForm form = _matchService.GetForm(matchId);
            return View(form);
        }
    }
}