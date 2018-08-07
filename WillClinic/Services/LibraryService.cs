using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WillClinic.Data;
using WillClinic.Models;

namespace WillClinic.Services
{
    // Refer to ILibraryService.cs for documentation
    public class LibraryService : ILibraryService
    {
        private readonly ApplicationDbContext _context;

        public LibraryService(ApplicationDbContext applicationDbContext)
        {
            _context = applicationDbContext;
        }

        public IEnumerable<Library> GetAllLibraries() => _context.Libraries;
        
        public Task<IEnumerable<Library>> FindLibrariesByNameAsync(string name)
        {
            throw new NotImplementedException();
        }

        public async Task<Library> FindLibraryByIdAsync(long id) => await _context.Libraries.FindAsync(id);

        public async Task<IEnumerable<Library>> GetAllLibrariesForLawyerAsync(string lawyerId) =>
            await _context.LawyerLibraryJunctions.Where(llj => llj.LawyerId == lawyerId)
                                                 .Include(llj => llj.Library)
                                                 .Select(llj => llj.Library)
                                                 .ToListAsync();

        public async Task<IEnumerable<Library>> GetAllLibrariesForVeteranAsync(string veteranId) =>
            await _context.VeteranLibraryJunctions.Where(llj => llj.VeteranId == veteranId)
                                                 .Include(llj => llj.Library)
                                                 .Select(llj => llj.Library)
                                                 .ToListAsync();

        /// <summary>
        /// method that gets all of the libraries that lawyers have associated them with
        /// The .join is preferred because it has a time complexity of O(N) vs. using a .where and .contains, which
        /// has a time complexity of O(N^2).
        /// The previous implementations have been commented out but not deleted to show what's conceptually being added.
        /// </summary>
        /// <returns>IEnumerable collection of Library objects</returns>
        public async Task<IEnumerable<Library>> GetAllLibrariesWithLawyers()
        {
            List<long> libIDs = await _context.LawyerLibraryJunctions.Select(l => l.LibraryId).Distinct().ToListAsync();

            // implementation 1:
            //List<Library> libraries = new List<Library>();
            //foreach (var item in libIDs)
            //{
            //    libraries.Add(await _context.Libraries.FirstOrDefaultAsync(l => l.ID == item));
            //}

            // implementation 2:
            //List<Library> libraries = await _context.Libraries.Where(l => libIDs.Contains(l.ID)).ToListAsync();

            List<Library> libraries = await _context.Libraries.Join(libIDs, lib => lib.ID, id => id, (lib, id) => lib).ToListAsync();

            return libraries;
        }
    }
}
