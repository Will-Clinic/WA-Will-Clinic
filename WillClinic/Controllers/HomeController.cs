using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WillClinic.Models;

namespace WillClinic.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                if (User.IsInRole(ApplicationRoles.Lawyer))
                {
                    return RedirectToPage("/Lawyers/Index");
                }
                else if (User.IsInRole(ApplicationRoles.Veteran))
                {
                    return RedirectToPage("/Veterans/Index");
                }
                else if (User.IsInRole(ApplicationRoles.Admin))
                {
                    return RedirectToAction(nameof(Index), "Admin");
                }
            }
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel {
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
