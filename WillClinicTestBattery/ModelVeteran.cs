using System;
using System.Collections.Generic;
using System.Text;
using WillClinic.Models;
using Xunit;

namespace WillClinicTestBattery
{
    public class ModelVeteran
    {
        private ApplicationUser _user { get; set; }
        private VeteranLawyerMatch _match { get; set; }

        public ModelVeteran()
        {
            _user = new ApplicationUser()
            {
                Id = "00000000-0000-0000-0000-000000000000",
                Email = "username@domain.tld",
                FirstName = "John",
                LastName = "Doe",
                MiddleInitial = "H",
                UserName = "username@domain.tld"
            };

            _match = new VeteranLawyerMatch()
            {
                ID = 1,
                LawyerApplicationUserId = "1",
                Veteran = new Veteran(),
                Lawyer = new Lawyer(),
                VeteranApplicationUserId = "1",
                IsDateTimeApproved = true,
                IsLocationApproved = true,
                LocationSelected = "Library",
            };

        }

        [Fact]
        public void SetGetID()
        {
            Veteran veteran = new Veteran()
            {
                ApplicationUserId = _user.Id,

                ApplicationUser = _user
            };

            Assert.Equal("00000000-0000-0000-0000-000000000000", veteran.ApplicationUserId);
        }

        [Fact]
        public void GetSetCity()
        {
            Veteran veteran = new Veteran()
            {
                City = "Seattle"
            };
            Assert.Matches("Seattle", veteran.City);

            veteran.City = "Redmond";
            Assert.Matches("Redmond", veteran.City);
        }

        [Fact]
        public void GetSetState()
        {
            Veteran veteran = new Veteran()
            {
                State = "Washington"
            };
            Assert.Matches("Washington", veteran.State);

            veteran.State = "California";
            Assert.Matches("California", veteran.State);
        }

        [Fact]
        public void GetSetZIP()
        {
            Veteran veteran = new Veteran()
            {
                ZipCode = 98122
            };
            Assert.Equal(98122, veteran.ZipCode);

            veteran.ZipCode = 98121;
            Assert.Equal(98121, veteran.ZipCode);
        }

        //[Fact]
        //public void ChildrenSetGet()
        //{
        //    Veteran veteran = new Veteran()
        //    {
        //        ApplicationUserId = _user.Id,

        //        ApplicationUser = _user
        //    };

        //    veteran.Children = "" ;

        //    Assert.Collection("", veteran.Children);
        //}

        // Testing Coordinates
        [Fact]
        public void Coordinates_TestingGetter_ReturnString()
        {
            // Arrange
            Veteran n = new Veteran();

            // Act
            n.Coordinates = "Veteran";

            // Assert
            Assert.Equal("Veteran", n.Coordinates);
        }

        [Fact]
        public void Coordinates_TestingSetter_ReturnString()
        {
            // Arrange
            Veteran n = new Veteran() { Coordinates = "Lawyer" };

            // Act
            n.Coordinates = "Veteran";

            // Assert
            Assert.Equal("Veteran", n.Coordinates);
        }

        [Fact]
        public void SetGetMatchID()
        {
            Veteran veteran = new Veteran()
            {
                ApplicationUserId = _match.ID.ToString(),

                VetLawMatch = _match,
            };
            Assert.Equal("1", veteran.VetLawMatch.ID.ToString());
        }

        [Fact]
        public void SetGetLawyerId()
        {
            Veteran veteran = new Veteran()
            {
                ApplicationUserId = _match.LawyerApplicationUserId,

                VetLawMatch = _match
            };

            Assert.Equal("1", veteran.VetLawMatch.LawyerApplicationUserId);
        }

        [Fact]
        public void SetGetVetId()
        {
            Veteran veteran = new Veteran()
            {
                ApplicationUserId = _match.VeteranApplicationUserId,

                VetLawMatch = _match
            };

            Assert.Equal("1", veteran.VetLawMatch.VeteranApplicationUserId);
        }


        [Fact]
        public void LocationSelected_TestingGetter_ReturnString()
        {
            // Arrange
            VeteranLawyerMatch n = new VeteranLawyerMatch();
            // Act
            n.LocationSelected = "Library";
            // Assert
            Assert.Equal("Library", n.LocationSelected);
        }

        [Fact]
        public void LocationSelected_TestingSetter_ReturnString()
        {
            // Arrange
            VeteranLawyerMatch n = new VeteranLawyerMatch() { LocationSelected = "Library" };
            // Act
            n.LocationSelected = "Library";
            // Assert
            Assert.Equal("Library", n.LocationSelected);
        }

    }
}
