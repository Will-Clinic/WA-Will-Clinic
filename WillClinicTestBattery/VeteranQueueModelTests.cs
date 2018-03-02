using System;
using System.Collections.Generic;
using System.Text;
using WillClinic.Models;
using Xunit;

namespace WillClinicTestBattery
{
    public class VeteranQueueModelTests
    {
        // Testing VeteranApplicationUserId
        [Fact]
        public void VeteranApplicationUserId_TestingGetter_ReturnString()
        {
            // Arrange
            VeteranQueue n = new VeteranQueue();

            // Act
            n.VeteranApplicationUserId = "Veteran";

            // Assert
            Assert.Equal("Veteran", n.VeteranApplicationUserId);
        }

        [Fact]
        public void VeteranApplicationUserId_TestingSetter_ReturnString()
        {
            // Arrange
            VeteranQueue n = new VeteranQueue() { VeteranApplicationUserId = "Lawyer" };

            // Act
            n.VeteranApplicationUserId = "Veteran";

            // Assert
            Assert.Equal("Veteran", n.VeteranApplicationUserId);
        }
    }
}
