using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
            //Models.ClientFinder clientFinder = new Models.ClientFinder();
            // NOT YET IMPLEMENTED
            return View();
        }
    }
}
