using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WillClinic.Models;

namespace WillClinic.Services
{
    public interface IAvailabilityService
    {
        Task<bool> UpdateAsync(LawyerAvailability availability);
        Task<bool> AddAsync(LawyerAvailability availability);
        Task<bool> AddLibraryJunctionAsync(LibraryAvailabilityJunction junction);
    }
}
