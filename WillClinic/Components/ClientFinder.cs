using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WillClinic.Components
{
    public class ClientFinder : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            //Models.ClientFinder clientFinder = new Models.ClientFinder();
            // NOT YET IMPLEMENTED
            return View();
        }
    }
}
