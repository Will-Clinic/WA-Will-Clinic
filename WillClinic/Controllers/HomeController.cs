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
                if (User.IsInRole("Lawyer"))
                {
                    return RedirectToAction("Index", "Lawyer");
                }
                //else if (User.IsInRole("Veteran"))
                //{
                //    RedirectToAction("Index", "Veteran");
                //}
                //else if (User.IsInRole("Admin"))
                //{
                //    RedirectToAction("Index", "Admin");
                //}
                else
                {
                    return View();
                }
            }
            else
            {
                return View();
            }
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
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
