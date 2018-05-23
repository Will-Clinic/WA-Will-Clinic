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
        
        public Task<Library> FindLibraryByNameAsync(string name)
        {
            throw new NotImplementedException();
        }
    }
}
