using System;
using System.Collections.Generic;
using System.Text;
using WillClinic.Models;
using Xunit;

namespace WillClinicTestBattery
{
    public class LawyerAvailabiltyModelTests
    {
        // Testing LawyerApplicationUserId
        [Fact]
        public void LawyerApplicationUserId_TestingGetter_ReturnString()
        {
            // Arrange
            LawyerAvailability n = new LawyerAvailability();

            // Act
            n.LawyerApplicationUserId = "Veteran";

            // Assert
            Assert.Equal("Veteran", n.LawyerApplicationUserId);
        }

        [Fact]
        public void LawyerApplicationUserId_TestingSetter_ReturnString()
        {
            // Arrange
            LawyerAvailability n = new LawyerAvailability() { LawyerApplicationUserId = "Lawyer" };

            // Act
            n.LawyerApplicationUserId = "Veteran";

            // Assert
            Assert.Equal("Veteran", n.LawyerApplicationUserId);
        }
    }
}
