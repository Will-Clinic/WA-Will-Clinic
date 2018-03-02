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
    public class MatchController : Controller
    {
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

        private ViewResult GetForms(VeteranLawyerMatch match)
        {
            List<VeteranIntakeForm> forms = _matchService.GetForms(match);
            return View(forms);
        }
    }
}