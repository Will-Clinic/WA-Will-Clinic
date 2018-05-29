using System;
using Xunit;
using WillClinic.Models;
using Microsoft.EntityFrameworkCore;
using WillClinic.Data;
using WillClinic.Controllers;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Net.Http;
using Newtonsoft.Json.Linq;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using Google.Apis.Logging;
using WillClinic.Models.Documents;


namespace WillClinicTestBattery
{
   public class DocumentModelTest
   {
        [Fact]
        public  void DocumentFirstNameTest()
        {
            AllDocsViewModel n = new AllDocsViewModel();

            n.FirstName = "James";

            Assert.Equal("James", n.FirstName);
        }

        [Fact]
        public void DocumentLastNameTest()
        {
            AllDocsViewModel n = new AllDocsViewModel();

            n.LastName = "Harrision";

            Assert.Equal("Harrision", n.LastName);
        }





    }
}
