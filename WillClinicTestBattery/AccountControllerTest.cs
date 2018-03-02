using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using WillClinic.Controllers;
using WillClinic.Data;
using WillClinic.Models;
using WillClinic.Services;
using Xunit;

namespace WillClinicTestBattery
    {
        public class AccountControllerTest
        {
            ApplicationDbContext _context;

            public ClaimsPrincipal User { get; set; }

            //public HomeController()
            //{
            //    User = new ClaimsPrincipal();

            //}


            DbContextOptions<ApplicationDbContext> options = new DbContextOptionsBuilder<ApplicationDbContext>()

                  .UseInMemoryDatabase(Guid.NewGuid().ToString())

                  .Options;

            [Fact]
            public void ReturnsView()
            {
                ClaimsPrincipal User = new ClaimsPrincipal();
                // Arrange
                HomeController homeController = new HomeController();

                // Act
                var result = homeController.Index();

                // Assert
                Assert.NotNull(result);

            }

            [Fact]
            public void determineindexreturnscorrectview()
            {
                HomeController controller = new HomeController();

                ViewResult result = controller.Index() as ViewResult;

                //****result.viewname is empty!!!!***//
                Assert.Equal("index", result.ViewName);
            }
        }
    }

