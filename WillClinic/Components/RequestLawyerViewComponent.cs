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
            if (_matchService.IsMatched())
            {
                VeteranLawyerMatch match = _matchService.GetMatch();
                if (!match.IsDateTimeApproved)
                {
                    match.Lawyer.Availability = _matchService.GetLawyerAvailability(match.LawyerApplicationUserId);
                    return View("MatchStage1", match);
                }
                else
                {
                    return View("MatchStage2", match);
                }
            }
            else if (_matchService.IsInQueue())
            {
                VeteranQueue queue = _matchService.GetQueueItem();
                return View("WaitingMatch", queue);
            }
            else if (!_matchService.HasCompletedForm())
            {
                return View("NoForm");
            }
            else
            {
                return View(); // "Default"
            }
        }
    }
}
