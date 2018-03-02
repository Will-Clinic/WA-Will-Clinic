using System;
using System.Collections.Generic;
using System.Text;
using WillClinic.Models;
using Xunit;

namespace WillClinicTestBattery
{
    public class VeteranLawyerMatchModelTests
    {

        // Testing VeteranApplicationUserId
        [Fact]
        public void VeteranApplicationUserId_TestingGetter_ReturnString()
        {
            // Arrange
            VeteranLawyerMatch n = new VeteranLawyerMatch();

            // Act
            n.VeteranApplicationUserId = "Veteran";

            // Assert
            Assert.Equal("Veteran", n.VeteranApplicationUserId);
        }

        [Fact]
        public void VeteranApplicationUserId_TestingSetter_ReturnString()
        {
            // Arrange
            VeteranLawyerMatch n = new VeteranLawyerMatch() { VeteranApplicationUserId = "Lawyer" };

            // Act
            n.VeteranApplicationUserId = "Veteran";

            // Assert
            Assert.Equal("Veteran", n.VeteranApplicationUserId);
        }

        public string LawyerApplicationUserId { get; set; }
        // Testing LawyerApplicationUserId
        [Fact]
        public void LawyerApplicationUserId_TestingGetter_ReturnString()
        {
            // Arrange
            VeteranLawyerMatch n = new VeteranLawyerMatch();

            // Act
            n.LawyerApplicationUserId = "Veteran";

            // Assert
            Assert.Equal("Veteran", n.LawyerApplicationUserId);
        }

        [Fact]
        public void LawyerApplicationUserId_TestingSetter_ReturnString()
        {
            // Arrange
            VeteranLawyerMatch n = new VeteranLawyerMatch() { LawyerApplicationUserId = "Lawyer" };

            // Act
            n.LawyerApplicationUserId = "Veteran";

            // Assert
            Assert.Equal("Veteran", n.LawyerApplicationUserId);
        }

        // Testing LocationSelected
        [Fact]
        public void LocationSelected_TestingGetter_ReturnString()
        {
            // Arrange
            VeteranLawyerMatch n = new VeteranLawyerMatch();

            // Act
            n.LocationSelected = "Veteran";

            // Assert
            Assert.Equal("Veteran", n.LocationSelected);
        }

        [Fact]
        public void LocationSelected_TestingSetter_ReturnString()
        {
            // Arrange
            VeteranLawyerMatch n = new VeteranLawyerMatch() { LocationSelected = "Lawyer" };

            // Act
            n.LocationSelected = "Veteran";

            // Assert
            Assert.Equal("Veteran", n.LocationSelected);
        }

        // Testing IsLocationApproved
        [Fact]
        public void IsDateTimeApproved_TestingGetter_ReturnBool()
        {
            // Arrange
            VeteranLawyerMatch n = new VeteranLawyerMatch();
            VeteranLawyerMatch parent = new VeteranLawyerMatch();

            // Act
            n.IsDateTimeApproved = true;
            parent.IsDateTimeApproved = true;

            // Assert
            Assert.True(n.IsDateTimeApproved);
            Assert.True(parent.IsDateTimeApproved);
        }


        [Fact]
        public void IsDateTimeApproved_TestingSetter_ReturnBool()
        {
            // Arrange
            VeteranLawyerMatch n = new VeteranLawyerMatch() { IsDateTimeApproved = false };

            // Act
            n.IsDateTimeApproved = true;

            // Assert
            Assert.True(n.IsDateTimeApproved);
        }


        public bool IsLocationApproved { get; set; }
        // Testing IsLocationApproved
        [Fact]
        public void IsLocationApproved_TestingGetter_ReturnBool()
        {
            // Arrange
            VeteranLawyerMatch n = new VeteranLawyerMatch();
            VeteranLawyerMatch parent = new VeteranLawyerMatch();


            // Act
            n.IsLocationApproved = true;
            parent.IsLocationApproved = true;

            // Assert
            Assert.True(n.IsLocationApproved);
            Assert.True(parent.IsLocationApproved);
        }


        [Fact]
        public void IsLocationApproved_TestingSetter_ReturnBool()
        {
            // Arrange
            VeteranLawyerMatch n = new VeteranLawyerMatch() { IsLocationApproved = false };

            // Act
            n.IsLocationApproved = true;

            // Assert
            Assert.True(n.IsLocationApproved);
        }



    }
}
