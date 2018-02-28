using System;
using System.Collections.Generic;
using System.Text;
using WillClinic.Models;
using Xunit;

namespace WillClinicTestBattery
{
    public class ModelVeteran
    {
        public ApplicationUser user { get; set; }

        public ModelVeteran()
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
            Veteran Veteran = new Veteran()
            {
                ApplicationUserId = user.Id,

                ApplicationUser = user
            };

            Assert.Equal("00000000-0000-0000-0000-000000000000", Veteran.ApplicationUserId);
        }

        [Fact]
        public void CitySetGet()
        {
            Veteran Veteran = new Veteran()
            {
                ApplicationUserId = user.Id,

                ApplicationUser = user
            };

            Veteran.City = "Seattle";

            Assert.Equal("Seattle", Veteran.City);
        }

        [Fact]
        public void StateSetGet()
        {
            Veteran Veteran = new Veteran()
            {
                ApplicationUserId = user.Id,

                ApplicationUser = user
            };

            Veteran.State = "Washington";

            Assert.Equal("Washington", Veteran.State);
        }

        [Fact]
        public void ZipSetGet()
        {
            Veteran Veteran = new Veteran()
            {
                ApplicationUserId = user.Id,

                ApplicationUser = user
            };

            Veteran.ZipCode = 99999;

            Assert.Equal(99999, Veteran.ZipCode);
        }

        [Fact]
        public void ChildrenSetGet()
        {
            Veteran Veteran = new Veteran()
            {
                ApplicationUserId = user.Id,

                ApplicationUser = user
            };

            Veteran.Children = "" ;

            Assert.Collection<VeteranChildren>("", Veteran.Children);
        }



    }
}
