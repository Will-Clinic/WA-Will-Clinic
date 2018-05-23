﻿using Microsoft.AspNetCore.Identity;
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

        public async Task<ICollection<LawyerAvailability>> GetLawyerAvailabilitiesAsync(Lawyer lawyer)
        {
            if (lawyer is null)
            {
                return null;
            }

            await _context.Entry(lawyer).Collection(l => l.Availability).LoadAsync();

            foreach (LawyerAvailability availability in lawyer.Availability)
            {
                await _context.Entry(availability).Reference(a => a.Library).LoadAsync();
            }

            return lawyer.Availability;
        }

        public async Task<Lawyer> GetLawyerByPrincipalAsync(ClaimsPrincipal principal)
        {
            ApplicationUser user = await _userManager.GetUserAsync(principal);

            if (user is null)
            {
                return null;
            }

            return await _context.Lawyers.FirstOrDefaultAsync(l => l.ApplicationUserId == user.Id);
        }

        public async Task<Lawyer> LockOutAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> TryUpdateAsync(Lawyer lawyer)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> VerifyBarStatus(int id)
        {
            throw new NotImplementedException();
        }
    }
}