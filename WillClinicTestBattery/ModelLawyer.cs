using System;
using WillClinic.Models;
using Xunit;

namespace WillClinicTestBattery
{
    public class ModelLawyer
    {
        public ApplicationUser user { get; set; }

        public ModelLawyer()
        {
            user = new ApplicationUser()
            {
                Id = "00000000-0000-0000-0000-000000000000",
                Email = "username@domain.tld",
                FirstName = "John",
                LastName = "Doe",
                MiddleInitial = "H",
                UserName = "username@domain.tld"
            };
        }

        [Fact]
        public void IdSetGet()
        {
            Lawyer Lawyer = new Lawyer()
            {
                ApplicationUserId = user.Id,

                ApplicationUser = user
            };

            Assert.Equal("00000000-0000-0000-0000-000000000000",Lawyer.ApplicationUserId);
        }

        [Fact]
        public void BarNumberSetGet()
        {
            Lawyer Lawyer = new Lawyer()
            {
                ApplicationUserId = user.Id,

                ApplicationUser = user
            };

            Lawyer.BarNumber = 123123123;

            Assert.Equal(123123123, Lawyer.BarNumber);
        }

        [Fact]
        public void CountrySetGet()
        {
            Lawyer Lawyer = new Lawyer()
            {
                ApplicationUserId = user.Id,

                ApplicationUser = user
            };

            Lawyer.Country = "United States";

            Assert.Equal("United States", Lawyer.Country);
        }

        [Fact]
        public void StateSetGet()
        {
            Lawyer Lawyer = new Lawyer()
            {
                ApplicationUserId = user.Id,

                ApplicationUser = user
            };

            Lawyer.State = "Washington";

            Assert.Equal("Washington", Lawyer.State);
        }

        [Fact]
        public void CitySetGet()
        {
            Lawyer Lawyer = new Lawyer()
            {
                ApplicationUserId = user.Id,

                ApplicationUser = user
            };

            Lawyer.City = "Seattle";

            Assert.Equal("Seattle", Lawyer.City);
        }

        [Fact]
        public void ZipSetGet()
        {
            Lawyer Lawyer = new Lawyer()
            {
                ApplicationUserId = user.Id,

                ApplicationUser = user
            };

            Lawyer.ZipCode = 99999;

            Assert.Equal(99999, Lawyer.ZipCode);
        }

        [Fact]
        public void PracticeAreasSetGet()
        {
            Lawyer Lawyer = new Lawyer()
            {
                ApplicationUserId = user.Id,

                ApplicationUser = user
            };

            Lawyer.PracticeAreas = "Kent, Tukwilla";

            Assert.Equal("Kent, Tukwilla", Lawyer.PracticeAreas);
        }

        [Fact]
        public void YearsOfExperienceSetGet()
        {
            Lawyer Lawyer = new Lawyer()
            {
                ApplicationUserId = user.Id,

                ApplicationUser = user
            };

            Lawyer.YearsOfExperience = 12;

            Assert.Equal(12, Lawyer.YearsOfExperience);
        }

        [Fact]
        public void LanguagesSetGet()
        {
            Lawyer Lawyer = new Lawyer()
            {
                ApplicationUserId = user.Id,

                ApplicationUser = user
            };

            Lawyer.OtherLanguages = true;

            Assert.True(Lawyer.OtherLanguages);
        }

        [Fact]
        public void AppUserUserNameGet()
        {
            Lawyer Lawyer = new Lawyer()
            {
                ApplicationUserId = user.Id,

                ApplicationUser = user
            };

            Assert.Equal("username@domain.tld", Lawyer.ApplicationUser.UserName);
        }

        // Testing Coordinates
        [Fact]
        public void Coordinates_TestingGetter_ReturnString()
        {
            // Arrange
            Lawyer n = new Lawyer();

            // Act
            n.Coordinates = "Veteran";

            // Assert
            Assert.Equal("Veteran", n.Coordinates);
        }

        [Fact]
        public void Coordinates_TestingSetter_ReturnString()
        {
            // Arrange
            Lawyer n = new Lawyer() { Coordinates = "Lawyer" };

            // Act
            n.Coordinates = "Veteran";

            // Assert
            Assert.Equal("Veteran", n.Coordinates);
        }
    }
}
