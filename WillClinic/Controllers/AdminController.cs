using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WillClinic.Data;
using WillClinic.Models;

namespace WillClinic.Controllers
{
    public class AdminController : Controller
    {
        readonly ApplicationDbContext _context;

        public AdminController(ApplicationDbContext ctx)
        {
            _context = ctx;
        }
        

        public IActionResult Index()
        {
         return View();            
        }

        public List<Lawyer> GetUnverifiedLawyers()
        {
            var results = _context.Lawyers.Where(x => x.IsVerified == false).ToList();
            return results;
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

    }
}