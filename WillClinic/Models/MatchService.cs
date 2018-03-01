using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WillClinic.Data;
using WillClinic.Models;
using WillClinic.Models.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;

namespace WillClinic.Models
{
    public class MatchService : IMatchService
    {
        public int Stage { get; set; }
        //public Request EarliestRequest { get; set; }
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public MatchService(UserManager<ApplicationUser> userManager, ApplicationDbContext context)
        {
            _context = context;
            _userManager = userManager;
            Stage = 0;
        }

        public bool IsInQueue()
        {
            return true;
            //if (_context.VeteranQueue.Any(v => v.VeteranApplicationUserId == )) return true;
            //else return false;
        }

        public void FindVeterans()
        {
            Stage = 1;

            // Populate Clients list with veterans found within a certain radius from Veterans table.
            // List<Request> requests = _context.Requests.ToList();

            //Sort requests by Id

            //Get lowest Id Request, assign to Earliest Request

            Stage = 2;
            
            //Show lawyer approximate meetup area and distance and maybe some other basic info
        }
    }
}
