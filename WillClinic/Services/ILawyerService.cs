using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using WillClinic.Models;

namespace WillClinic.Services
{
    public interface ILawyerService
    {
        Task<Lawyer> GetLawyerByPrincipalAsync(ClaimsPrincipal principal);
        Task<ICollection<LawyerAvailability>> GetLawyerAvailabilitiesAsync(Lawyer lawyer);
        Task<Lawyer> FindAsync(string id);
        Task<bool> TryUpdateAsync(Lawyer lawyer);
        Task<Lawyer> LockOutAsync(int id);

        Task<bool> VerifyBarStatus(int id);
    }
}
