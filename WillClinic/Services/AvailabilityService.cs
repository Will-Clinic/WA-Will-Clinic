using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WillClinic.Data;
using WillClinic.Models;

namespace WillClinic.Services
{
    public class AvailabilityService : IAvailabilityService
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<AvailabilityService> _logger;

        public AvailabilityService(ApplicationDbContext applicationDbContext,
            ILogger<AvailabilityService> logger)
        {
            _context = applicationDbContext;
            _logger = logger;
        }

        public async Task<bool> AddAsync(LawyerAvailability availability)
        {
            if (availability is null)
            {
                _logger.LogError("Attempt made to update availability using a null object");
                return false;
            }

            await _context.LawyerAvailability.AddAsync(availability);

            try
            {
                await _context.SaveChangesAsync();
                return true;
            }
            catch
            {
                _logger.LogError("Could not successfully commit availability creation to database");
                return false;
            }
        }

        public async Task<bool> UpdateAsync(LawyerAvailability availability)
        {
            if (availability is null)
            {
                _logger.LogError("Attempt made to update availability using a null object");
                return false;
            }

            _context.LawyerAvailability.Update(availability);

            try
            {
                await _context.SaveChangesAsync();
                return true;
            }
            catch
            {
                _logger.LogError("Could not successfully commit availability update to database");
                return false;
            }
        }
        
        public async Task<bool> AddLibraryJunctionAsync(LibraryAvailabilityJunction junction)
        {
            throw new NotImplementedException();
            /*
            if (junction is null)
            {
                _logger.LogError("Attempt made to update library availability junction using a null object");
                return false;
            }

            await _context.LibraryAvailabilityJunctions.AddAsync(junction);

            try
            {
                await _context.SaveChangesAsync();
                return true;
            }
            catch
            {
                _logger.LogError("Could not successfully commit library availability junction creation to database");
                return false;
            }
            */
        }
    }
}
