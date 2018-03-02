using System;
using System.Collections.Generic;
using System.Text;
using WillClinic.Models;
using Xunit;

namespace WillClinicTestBattery
{
    public class ErrorViewModelTests
    {
        // Testing RequestId
        [Fact]
        public void RequestId_TestingGetter_ReturnString()
        {
            // Arrange
            ErrorViewModel n = new ErrorViewModel();

            // Act
            n.RequestId = "Veteran";

            // Assert
            Assert.Equal("Veteran", n.RequestId);
        }

        [Fact]
        public void RequestId_TestingSetter_ReturnString()
        {
            // Arrange
            ErrorViewModel n = new ErrorViewModel() { RequestId = "Lawyer" };

            // Act
            n.RequestId = "Veteran";

            // Assert
            Assert.Equal("Veteran", n.RequestId);
        }

    }
}
