using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WillClinic.Data;
using WillClinic.Models;

namespace WillClinic.Services
{
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
    }
}
