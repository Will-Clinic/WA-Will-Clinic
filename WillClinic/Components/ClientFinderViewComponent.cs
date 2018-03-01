using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WillClinic.Models;
using WillClinic.Models.Interfaces;

namespace WillClinic.Components
{
    public class ClientFinderViewComponent : ViewComponent
    {
        private readonly IMatchService _matchService;

        public ClientFinderViewComponent(IMatchService matchService)
        {
            _matchService = matchService;
        }

        public IViewComponentResult Invoke()
        {
            if (_matchService.IsMatched())
            {
                List<VeteranLawyerMatch> list = _matchService.GetMatches();
                return View("CurrentMatches", list);
            }
            else
                return View(); // Default
        }
    }
}
