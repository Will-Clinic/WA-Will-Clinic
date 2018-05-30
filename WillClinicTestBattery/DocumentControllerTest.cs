using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using WillClinic;
using WillClinic.Controllers;
using WillClinic.Data;
using WillClinic.Models;
using WillClinic.Services;
using Xunit;

namespace WillClinicTestBattery
{
    public class DocumentControllerTest
    {
        //Test incomplete
        [Fact]
        public async void CanReturnView()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "testDb")
                .Options;
            var builder = new ConfigurationBuilder().AddEnvironmentVariables();
            builder.AddUserSecrets<Startup>();
            var configuration = builder.Build();

            //TODO populate test database

            using (var context = new ApplicationDbContext(options))
            {
                var controller = new DocumentController(context);
                //Needs id parameter to test
                //var results = controller.Confirmation();
            }

            //Assert.IsAssignableFrom<IActionResult>(result);
        }
    }
}
