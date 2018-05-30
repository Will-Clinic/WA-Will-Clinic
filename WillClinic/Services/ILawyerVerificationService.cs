using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WillClinic.Services
{
    public interface ILawyerVerificationService
    {
        Task<bool> IsValidLawyerAsync(int number, string email);
    }
}
