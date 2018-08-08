﻿using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using WillClinic.Data;
using WillClinic.Models;

namespace WillClinic.Services
{
    // Refer to IVeteranService.cs for documentation
    public class VeteranService : IVeteranService
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ILibraryService _libraryService;
        private readonly ILogger<VeteranService> _logger;

        public VeteranService(ApplicationDbContext applicationDbContext,
            UserManager<ApplicationUser> userManager,
            ILibraryService libraryService, ILogger<VeteranService> logger)
        {
            _context = applicationDbContext;
            _userManager = userManager;
            _libraryService = libraryService;
            _logger = logger;
        }

        public async Task<IEnumerable<Veteran>> GetPotentialClientsForLawyerAsync(string lawyerId) =>
            await _context.VeteranLibraryJunctions.Include(vlj => vlj.Veteran)
                                                  // OrderBy ensures that the returned veterans are sorted by the order in which they added their library selections
                                                  .OrderBy(vlj => vlj.TimeAdded)
                                                  .Join(_context.LawyerLibraryJunctions.Where(llj => llj.LawyerId == lawyerId),
                                                      vlj => vlj.LibraryId,
                                                      llj => llj.LibraryId,
                                                      (vlj, llj) => vlj.Veteran)
                                                  .Distinct()
                                                  // This Where clause prevents matching with veterans who have already made a match with a lawyer
                                                  .Where(v => !(_context.VeteranLawyerMatches.Any(vlm => vlm.VeteranApplicationUserId == v.ApplicationUserId)))
                                                  .ToListAsync();


        public async Task<Veteran> GetVeteranByPrincipalAsync(ClaimsPrincipal principal)
        {
            ApplicationUser user = await _userManager.GetUserAsync(principal);

            // Ensure that the provided claims principal actually corresponds to a Veteran entity in the database
            if (user is null)
            {
                return null;
            }

            return await _context.Veterans.Include(v => v.VeteranLibraryJunctions)
                                          .FirstOrDefaultAsync(v => v.ApplicationUserId == user.Id);
        }

        public async Task<Veteran> FindVeteranAsync(string id) =>
            await _context.Veterans.Include(v => v.VeteranLibraryJunctions)
                                   .FirstOrDefaultAsync(v => v.ApplicationUserId == id);

        public async Task<bool> MergeLibraryListWithVeteranAsync(string veteranId, IEnumerable<long> libraryIds)
        {
            IEnumerable<long> currentLibraryIds = _context.VeteranLibraryJunctions.Where(vlj => vlj.VeteranId == veteranId)
                                                                                  .Select(vlj => vlj.LibraryId);

            // Add all libraries in the provided IEnumerable argument which are not currently related to the veteran
            foreach (long libraryId in libraryIds.Except(currentLibraryIds))
            {
                await _context.VeteranLibraryJunctions.AddAsync(new VeteranLibraryJunction()
                {
                    VeteranId = veteranId,
                    LibraryId = libraryId,
                    TimeAdded = DateTime.UtcNow
                });
            }

            // Remove all junction table rows for existing libraries related to the veteran but not included in the libraryIds argument
            foreach (long libraryId in currentLibraryIds.Except(libraryIds))
            {
                _context.VeteranLibraryJunctions.Remove(
                    await _context.VeteranLibraryJunctions.FirstOrDefaultAsync(
                        vlj => vlj.VeteranId == veteranId && vlj.LibraryId == libraryId));
            }

            // Try to commit all changes to the database
            try
            {
                await _context.SaveChangesAsync();
                return true;
            }
            catch
            {
                _logger.LogError("Unable to merge library list with veteran via junction table");
                return false;
            }
        }

        public async Task<IEnumerable<VeteranLibraryJunction>> GetVeteranLibraryJunctionsAsync(string veteranId) =>
            await _context.VeteranLibraryJunctions.Where(vlj => vlj.VeteranId == veteranId)
                                                  .Include(vlj => vlj.Library)
                                                  .Include(vlj => vlj.Veteran)
                                                  .ToListAsync();
    }
}
