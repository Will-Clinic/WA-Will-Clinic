using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WillClinic.Data;

namespace WillClinic.Models
{
    public class ClientFinder
    {
        private readonly ApplicationDbContext _context;


        public int Stage { get; set; }

        public ICollection<VeteranQueue> Clients { get; set; }

        public ClientFinder(ApplicationDbContext context)
        {
            _context = context;
            Stage = 0;
        }

        public void FindVeterans()
        {
            Stage = 1;
            // Populate Clients list with veterans found within a certain radius from Veterans table.
            //_context.Veterans.Where(vet => vet.RequestLawyer != null);
        }
    }
}
