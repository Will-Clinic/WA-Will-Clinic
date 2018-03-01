using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WillClinic.Data;
using WillClinic.Models;
using WillClinic.Models.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace WillClinic.Models
{
    public class MatchService : IMatchService
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly HttpContext _httpContext;

        public MatchService(UserManager<ApplicationUser> userManager, ApplicationDbContext context, SignInManager<ApplicationUser> signInManager, IHttpContextAccessor httpc)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
            _httpContext = httpc.HttpContext;
        }

        public bool IsInQueue()
        {
            string userid = _userManager.GetUserId(_httpContext.User);

            if (_httpContext.User.IsInRole("Veteran"))
            {
                if (_context.VeteranQueue.Any(v => v.VeteranApplicationUserId == userid)) return true;
            }

            return false;
        }

        public bool IsMatched()
        {
            string userid = _userManager.GetUserId(_httpContext.User);

            if (_httpContext.User.IsInRole("Veteran"))
            {
                if (_context.VeteranLawyerMatches.Any(v => v.VeteranApplicationUserId == userid)) return true;
            }
            else if (_httpContext.User.IsInRole("Lawyer"))
            {
                if (_context.VeteranLawyerMatches.Any((v => v.LawyerApplicationUserId == userid))) return true;
            }

            return false;
        }

        public void AddtoQueue(string userid)
        {
            if (!IsInQueue())
            {
                VeteranQueue vq = new VeteranQueue();
                vq.TimeEnteredQueue = DateTime.Now;
                vq.VeteranApplicationUserId = userid;

                _context.VeteranQueue.Add(vq);
                _context.SaveChanges();
            }

            // Check if user is in queue

            // If not --> gives them a view from the VC that provides a button to be put in th queue.

            // if they don't have any valid applicaitons 
            // the njust show them a message that says "no applications found...."

            // if they are in the match table --> then rturn a view that shows them the lawyer they are matched with
            // show available times frm that lawyer
            // IsDateTimeApproved --> if no shows available time slots
            // if yes --> deets of the meeting.
        }

        public void FindVeteran()
        {
            if (_context.VeteranQueue.Any())
            {
                string userid = _userManager.GetUserId(_httpContext.User);
                VeteranQueue vq = _context.VeteranQueue.First();

                VeteranLawyerMatch newMatch = new VeteranLawyerMatch();
                newMatch.IsDateTimeApproved = false;
                newMatch.IsLocationApproved = false;
                newMatch.LawyerApplicationUserId = userid;
                newMatch.VeteranApplicationUserId = vq.VeteranApplicationUserId;

                _context.VeteranLawyerMatches.Add(newMatch);
                _context.SaveChanges();
                _context.VeteranQueue.Remove(vq);
                _context.SaveChanges();
            }
        }

        public List<VeteranLawyerMatch> GetMatches()
        {
            string userid = _userManager.GetUserId(_httpContext.User);
            List<VeteranLawyerMatch> list = new List<VeteranLawyerMatch>();
            list = _context.VeteranLawyerMatches
                .Include(match => match.Veteran.IntakeForms .Where(form => form.IsCompleted != null) .Where(form => form.IsCompleted == true))
                .Include(match => match.Veteran.ApplicationUser) .Where(x => x.LawyerApplicationUserId == userid)
                .ToList();
            return list;
        }

        public VeteranLawyerMatch GetMatch()
        {
            string userid = _userManager.GetUserId(_httpContext.User);
            VeteranLawyerMatch match = _context.VeteranLawyerMatches.First(x => x.VeteranApplicationUserId == userid);
            match.Lawyer = _context.Lawyers.Find(match.LawyerApplicationUserId);
            match.Lawyer.ApplicationUser = _context.Users.Find(match.Lawyer.ApplicationUserId);
            return match;
        }
    }
}
