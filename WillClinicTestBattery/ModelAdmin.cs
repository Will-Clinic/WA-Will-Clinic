using System;
using WillClinic.Models;
using Xunit;

namespace WillClinicTestBattery
{
    public class ModelAdmin
    {
        public ApplicationUser user { get; set; }

        public ModelAdmin()
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
            Admin Admin = new Admin()
            {
                ApplicationUserId = user.Id,

                ApplicationUser = user
            };

            Assert.Equal("00000000-0000-0000-0000-000000000000",Admin.ApplicationUserId);
        }

        [Fact]
        public void AppUserUserNameGet()
        {
            Admin Admin = new Admin()
            {
                ApplicationUserId = user.Id,

                ApplicationUser = user
            };

            Assert.Equal("username@domain.tld", Admin.ApplicationUser.UserName);
        }
    }
}
