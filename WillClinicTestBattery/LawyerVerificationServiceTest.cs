using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using WillClinic.Services;
using System.Threading.Tasks;

namespace WillClinicTestBattery
{
    public class LawyerVerificationServiceTest
    {
        private readonly ILawyerVerificationService _service;
        public LawyerVerificationServiceTest (LawyerVerificationService service)
        {
            _service = service;
        }
        [Fact]
        public async Task  CanIdentifyValidLawyerAsync()
        {
            Assert.True(await _service.IsValidLawyerAsync(51146, "gregg0798@gmail.com"));
        }

        [Theory]
        [InlineData(9999, "")]
        [InlineData(10500, "")]
        [InlineData(51146, "gregg0798@mail.com")]
        [InlineData(51146, "")]
        [InlineData(51146, "gregg0798@gmail.coms")]
        [InlineData(51146, "ggregg0798@gmail.com")]
        public async Task CanDisqualifyLawyerAsync(int num, string email)
        {
            Assert.False(await _service.IsValidLawyerAsync(num, email));
        }
    }
}
