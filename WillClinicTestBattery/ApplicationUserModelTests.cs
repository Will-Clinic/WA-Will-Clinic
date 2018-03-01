using System;
using System.Collections.Generic;
using System.Text;
using WillClinic.Models;
using Xunit;


namespace WillClinicTestBattery
{
    public class ApplicationUserModelTests
    {
        // Testing FirstName
        [Fact]
        public void FirstName_TestingGetter_ReturnString()
        {
            // Arrange
            ApplicationUser n = new ApplicationUser();

            // Act
            n.FirstName = "Veteran";

            // Assert
            Assert.Equal("Veteran", n.FirstName);
        }

        [Fact]
        public void FirstName_TestingSetter_ReturnString()
        {
            // Arrange
            ApplicationUser n = new ApplicationUser() { FirstName = "Lawyer" };

            // Act
            n.FirstName = "Veteran";

            // Assert
            Assert.Equal("Veteran", n.FirstName);
        }

        // Testing MiddleInitial
        [Fact]
        public void MiddleInitial_TestingGetter_ReturnString()
        {
            // Arrange
            ApplicationUser n = new ApplicationUser();

            // Act
            n.MiddleInitial = "V";

            // Assert
            Assert.Equal("V", n.MiddleInitial);
        }

        [Fact]
        public void MiddleInitial_TestingSetter_ReturnString()
        {
            // Arrange
            ApplicationUser n = new ApplicationUser() { MiddleInitial = "L" };

            // Act
            n.MiddleInitial = "V";

            // Assert
            Assert.Equal("V", n.MiddleInitial);
        }

        // Testing LastName
        [Fact]
        public void LastName_TestingGetter_ReturnString()
        {
            // Arrange
            ApplicationUser n = new ApplicationUser();

            // Act
            n.LastName = "Veteran";

            // Assert
            Assert.Equal("Veteran", n.LastName);
        }

        [Fact]
        public void LastName_TestingSetter_ReturnString()
        {
            // Arrange
            ApplicationUser n = new ApplicationUser() { LastName = "Lawyer" };

            // Act
            n.LastName = "Veteran";

            // Assert
            Assert.Equal("Veteran", n.LastName);
        }

    }
}
