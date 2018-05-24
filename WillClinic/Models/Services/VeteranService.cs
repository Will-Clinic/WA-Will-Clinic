using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WillClinic.Data;

namespace WillClinic.Models.Services
{
    public class VeteranService : IVeteranService
    {
        private ApplicationDbContext _context;
        public VeteranService()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase("WaWillClinicDevDb")
                .Options;
            _context = new ApplicationDbContext(options);
        }

        public VeteranService(ApplicationDbContext context)
        {
            _context = context;
        }

        public Veteran Find(int id)
        {
            return _context.Veterans.FirstOrDefault(v => v.Id == id);
        }

        public Task<Veteran> FindAsync(int id)
        {
            return _context.Veterans.FirstOrDefaultAsync(v => v.Id == id);
        }

        public async Task SaveAsync(Veteran veteran)
        {
            var exsist = veteran.Id == default(int);

            _context.Entry(veteran).State = exsist ? EntityState.Added : EntityState.Modified;

            await _context.SaveChangesAsync();
        }
    }
}
