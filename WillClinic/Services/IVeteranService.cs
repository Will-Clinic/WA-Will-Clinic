using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using WillClinic.Models;

namespace WillClinic.Services
{
    public interface IVeteranService
    {
        Task<Veteran> GetVeteranByPrincipalAsync(ClaimsPrincipal principal);
        Task<bool> MergeLibraryListWithVeteranAsync(string veteranId, IEnumerable<long> libraryIds);
        Task<IEnumerable<Veteran>> GetPotentialClientsForLawyerAsync(string lawyerId);
        Task<Veteran> FindVeteranAsync(string id);
        Task<IEnumerable<VeteranLibraryJunction>> GetVeteranLibraryJunctionsAsync(string veteranId);
    }
}
