using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;
using WillClinic.Controllers;
using Microsoft.EntityFrameworkCore;
using System.Net.Http;
using System.Linq;
using WillClinic.Data;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System.Security.Claims;

using Moq;
using Xunit;
using Google.Apis.Logging;
using WillClinic.Models;

namespace WillClinicTestBattery
{
    public class LawyerControllerTest
    {
        DbContextOptions<ApplicationDbContext> options = new DbContextOptions<ApplicationDbContext>();

        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ILogger _logger;

        /*
        [Fact]
        public void LawyerView()
        {
            const string roleManager = "roleManager";

           var userId = Guid.NewGuid().ToString();

            var LawyerController = new Mock<>

            LawyerController lawyer = new LawyerController();

            IActionResult result = lawyer.
        }*/

            /*
        [Fact]
        public void LawyerView()
        {
            LawyerController home = new LawyerController();

            IActionResult result = home.Index();

            Assert.IsType<ViewResult>(result);
        }*/






    }
}
