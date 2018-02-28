﻿using System;
using System.Collections.Generic;
using System.Text;
using WillClinic.Models;
using Xunit;

namespace WillClinicTestBattery
{
    public class ModelVeteran
    {
        private ApplicationUser _user { get; set; }

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
        }

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
                ZIP = "98122"
            };
            Assert.Matches("98122", veteran.ZIP);

            veteran.ZIP = "98121";
            Assert.Matches("98121", veteran.ZIP);
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
