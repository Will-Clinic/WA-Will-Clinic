using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Claims;
using System.Threading.Tasks;
using WillClinic.Data;
using WillClinic.Models;

namespace WillClinic.Services
{
    // Refer to ILawyerService.cs for documentation
    public class LawyerService : ILawyerService
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ILogger<LawyerService> _logger;

        public LawyerService(ApplicationDbContext applicationDbContext,
            UserManager<ApplicationUser> userManager, ILogger<LawyerService> logger)
        {
            _context = applicationDbContext;
            _userManager = userManager;
            _logger = logger;
        }

        public async Task<Lawyer> FindAsync(string id) => await _context.Lawyers.FindAsync(id);

        public async Task<Lawyer> GetLawyerByPrincipalAsync(ClaimsPrincipal principal)
        {
            ApplicationUser user = await _userManager.GetUserAsync(principal);

            if (user is null)
            {
                return null;
            }

            return await _context.Lawyers.Include(l => l.LawyerSchedules)
                                         .Include(l => l.LawyerLibraryJunctions)
                                         .FirstOrDefaultAsync(l => l.ApplicationUserId == user.Id);
        }

        public async Task<IEnumerable<LawyerSchedule>> GetSchedulesAsync(string lawyerId) =>
            await _context.LawyerSchedules.Where(s => s.LawyerId == lawyerId)
                                          .ToListAsync();

        public async Task<bool> AddScheduleAsync(LawyerSchedule lawyerSchedule)
        {
            if (lawyerSchedule is null)
            {
                _logger.LogError("Tried to add null object as schedule");
                return false;
            }

            await _context.LawyerSchedules.AddAsync(lawyerSchedule);

            try
            {
                await _context.SaveChangesAsync();
                return true;
            }
            catch
            {
                _logger.LogError("Could not commit lawyer schedule creation");
                return false;
            }
        }

        public async Task<bool> UpdateScheduleAsync(LawyerSchedule lawyerSchedule)
        {
            if (lawyerSchedule is null || !(await _context.LawyerSchedules.AnyAsync(ls => ls.ID == lawyerSchedule.ID)))
            {
                _logger.LogError("Tried to update null or non-existant schedule");
                return false;
            }

            _context.LawyerSchedules.Update(lawyerSchedule);

            try
            {
                await _context.SaveChangesAsync();
                return true;
            }
            catch
            {
                _logger.LogError("Could not commit lawyer schedule update");
                return false;
            }
        }

        public async Task<bool> LockOutAsync(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> TryUpdateAsync(Lawyer lawyer)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> VerifyBarStatus(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> DeleteScheduleAsync(LawyerSchedule lawyerSchedule)
        {
            if (lawyerSchedule is null || !(await _context.LawyerSchedules.AnyAsync(ls => ls.ID == lawyerSchedule.ID)))
            {
                _logger.LogError("Tried to remove null or non-existant schedule from database");
                return false;
            }

            _context.LawyerSchedules.Remove(lawyerSchedule);

            try
            {
                await _context.SaveChangesAsync();
                return true;
            }
            catch
            {
                _logger.LogError("Unable to commit deletion of schedule from database");
                return false;
            }
        }

        public async Task<bool> AddLibraryToLawyerAsync(string lawyerId, long libraryId)
        {
            if (await _context.LawyerLibraryJunctions.AnyAsync(llj =>
                llj.LawyerId == lawyerId && llj.LibraryId == libraryId))
            {
                return false;
            }

            await _context.LawyerLibraryJunctions.AddAsync(new LawyerLibraryJunction()
            {
                LibraryId = libraryId,
                LawyerId = lawyerId
            });

            try
            {
                await _context.SaveChangesAsync();
                return true;
            }
            catch
            {
                _logger.LogError("Could not add library to lawyer via junction table");
                return false;
            }
        }

        public async Task<bool> RemoveLibraryFromLawyerAsync(string lawyerId, long libraryId)
        {
            LawyerLibraryJunction junction = await _context.LawyerLibraryJunctions.FirstOrDefaultAsync(llj =>
                llj.LawyerId == lawyerId && llj.LibraryId == libraryId);

            if (junction is null)
            {
                _logger.LogError("Tried to remove non-existant library lawyer junction from database");
                return false;
            }

            _context.LawyerLibraryJunctions.Remove(junction);

            try
            {
                await _context.SaveChangesAsync();
                return true;
            }
            catch
            {
                _logger.LogError("Could not add library to lawyer via junction table");
                return false;
            }
        }

        public async Task<bool> MergeLibraryListWithLawyerAsync(string lawyerId, IEnumerable<long> libraryIds)
        {
            IEnumerable<long> currentLibraryIds = _context.LawyerLibraryJunctions.Where(llj => llj.LawyerId == lawyerId)
                                                                                 .Select(llj => llj.LibraryId);

            foreach (long libraryId in libraryIds.Except(currentLibraryIds))
            {
                await _context.LawyerLibraryJunctions.AddAsync(new LawyerLibraryJunction()
                {
                    LawyerId = lawyerId,
                    LibraryId = libraryId
                });
            }

            // TODO(taylorjoshuaw): Replace with a LINQ query. This is not efficient at all
            foreach (long libraryId in currentLibraryIds.Except(libraryIds))
            {
                _context.LawyerLibraryJunctions.Remove(
                    await _context.LawyerLibraryJunctions.FirstOrDefaultAsync(
                        llj => llj.LawyerId == lawyerId && llj.LibraryId == libraryId));
            }

            try
            {
                await _context.SaveChangesAsync();
                return true;
            }
            catch
            {
                _logger.LogError("Unable to merge library list with lawyer via junction table");
                return false;
            }
        }

        public async Task<bool> MatchWithVeteranAsync(string lawyerId, string veteranId)
        {
            if (await _context.VeteranLawyerMatches.AnyAsync(vlm => vlm.VeteranApplicationUserId == veteranId))
            {
                _logger.LogError("Tried to match a lawyer with a veteran who is already matched");
                return false;
            }

            if (!(await _context.Lawyers.AnyAsync(l => l.ApplicationUserId == lawyerId)) ||
                !(await _context.Veterans.AnyAsync(v => v.ApplicationUserId == veteranId)))
            {
                _logger.LogError("Attempted to match a veteran and lawyer but could not find one of the entities");
                return false;
            }

            await _context.VeteranLawyerMatches.AddAsync(new VeteranLawyerMatch()
            {
                LawyerApplicationUserId = lawyerId,
                VeteranApplicationUserId = veteranId,
            });

            try
            {
                await _context.SaveChangesAsync();
                _logger.LogInformation("Successfully started matching process between lawyer and veteran");
                return true;
            }
            catch
            {
                _logger.LogError("Could not matching lawyer with a veteran");
                return false;
            }
        }
    }
}
