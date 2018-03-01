using System;
using System.Collections.Generic;
using System.Text;
using WillClinic.Models;
using Xunit;

namespace WillClinicTestBattery
{
    public class VeteranChildModelTest
    {
    
        // Testing MotherOfChildName
        [Fact]
        public void MotherOfChildName_TestingGetter_ReturnString()
        {
            // Arrange
            VeteranChild n = new VeteranChild();

            // Act
            n.MotherOfChildName = "Veteran";

            // Assert
            Assert.Equal("Veteran", n.MotherOfChildName);
        }

        [Fact]
        public void MotherOfChildName_TestingSetter_ReturnString()
        {
            // Arrange
            VeteranChild n = new VeteranChild() { MotherOfChildName = "Lawyer" };

            // Act
            n.MotherOfChildName = "Veteran";

            // Assert
            Assert.Equal("Veteran", n.MotherOfChildName);
        }

        // Testing VeteranApplicationUserId
        [Fact]
        public void VeteranApplicationUserId_TestingGetter_ReturnString()
        {
            // Arrange
            VeteranChild n = new VeteranChild();

            // Act
            n.VeteranApplicationUserId = "Veteran";

            // Assert
            Assert.Equal("Veteran", n.VeteranApplicationUserId);
        }

        [Fact]
        public void VeteranApplicationUserId_TestingSetter_ReturnString()
        {
            // Arrange
            VeteranChild n = new VeteranChild() { VeteranApplicationUserId = "Lawyer" };

            // Act
            n.VeteranApplicationUserId = "Veteran";

            // Assert
            Assert.Equal("Veteran", n.VeteranApplicationUserId);
        }

        // Testing FullName
        [Fact]
        public void FullName_TestingGetter_ReturnString()
        {
            // Arrange
            VeteranChild n = new VeteranChild();

            // Act
            n.FullName = "Veteran";

            // Assert
            Assert.Equal("Veteran", n.FullName);
        }

        [Fact]
        public void FullName_TestingSetter_ReturnString()
        {
            // Arrange
            VeteranChild n = new VeteranChild() { FullName = "Lawyer" };

            // Act
            n.FullName = "Veteran";

            // Assert
            Assert.Equal("Veteran", n.FullName);
        }

    }
}
