using System;
using Xunit;
using WillClinic.Models;
using Microsoft.EntityFrameworkCore;
using WillClinic.Data;
using WillClinic.Controllers;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Net.Http;

using Newtonsoft.Json.Linq;
using System.Security.Claims;

namespace WillClinicTestBattery
{
    public class ModelHomeController
    {
        ApplicationDbContext _context;

        public  ClaimsPrincipal User { get; set; }

        public ModelHomeController()
        {
            User = new ClaimsPrincipal();

        }


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
