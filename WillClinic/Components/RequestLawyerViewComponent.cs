using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WillClinic.Models.Interfaces;

namespace WillClinic.Components
{
    public class RequestLawyerViewComponent : ViewComponent
    {
        private readonly IMatchService _matchService;

        public RequestLawyerViewComponent(IMatchService matchService)
        {
            _matchService = matchService;
        }

        public IViewComponentResult Invoke()
        {
            if (_matchService.IsInQueue()) return View();
            else return View();
        }
    }
}
