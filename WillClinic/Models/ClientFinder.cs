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

        public Request EarliestRequest { get; set; }

        public ClientFinder(ApplicationDbContext context)
        {
            _context = context;
            Stage = 0;
        }

        public void FindVeterans()
        {
            Stage = 1;

            // Populate Clients list with veterans found within a certain radius from Veterans table.
            List<Request> requests = _context.Requests.ToList();

            //Sort requests by Id

            //Get lowest Id Request, assign to Earliest Request

            Stage = 2;
            
            //Show lawyer approximate meetup area and distance and maybe some other basic info
        }
    }
}
