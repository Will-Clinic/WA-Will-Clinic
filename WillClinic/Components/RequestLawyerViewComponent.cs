using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WillClinic.Models;
using WillClinic.Models.Interfaces;

namespace WillClinic.Components
{
    public class RequestLawyerViewComponent : ViewComponent
    {
        private readonly IMatchService _matchService;
        private readonly UserManager<ApplicationUser> _userManager;
        

        public RequestLawyerViewComponent(IMatchService matchService, UserManager<ApplicationUser> userManager)
        {
            _matchService = matchService;
            _userManager = userManager;
        }

        public IViewComponentResult Invoke()
        {
            // Make sure the user exists in the queue
            // if they do --> Show the waiting match VC
            // if they are not in the queue, show not in queue VC

            // bool status = _matchService.GetStatus();

            if (_matchService.IsInQueue()) return View("WaitingMatch");
            else if (_matchService.IsMatched())
            {
                VeteranLawyerMatch match = _matchService.GetMatch();
                return View("CurrentMatch", match);
            }
            else return View(); // Default
        }
    }
}
