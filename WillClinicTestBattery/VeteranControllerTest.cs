using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using WillClinic.Models;
using Microsoft.EntityFrameworkCore;
using WillClinic.Data;
using WillClinic.Controllers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Net.Http;

using Newtonsoft.Json.Linq;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using Google.Apis.Logging;
using WillClinic.Services;

namespace WillClinicTestBattery
{
    public class VeteranControllerTest
    {

        DbContextOptions<ApplicationDbContext> options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString())
            .Options;

       private readonly RoleManager<IdentityRole> _roleManager;
       private readonly UserManager<ApplicationUser> _userManager;
       private readonly SignInManager<ApplicationUser> _signInManager;
       private readonly IEmailSender _emailSender;
       private readonly ILogger _logger;
       private readonly ApplicationDbContext _context;

        /*
        [Fact]
        public void VeternResultView()
        {
            VeteranController veteran = new VeteranController();
        

            

            IActionResult Register = veteran.Register();

            Assert.IsType<ViewResult>();
        }*/


    }
}
