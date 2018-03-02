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

        /// <summary>
        /// Action for Veteran. 
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// Action for Veteran.
        /// </summary>
        /// <param name="userid"></param>
        public void AddtoQueue(string userid)
        {
            if (!IsInQueue() && !IsMatched())
            {
                VeteranQueue vq = new VeteranQueue();
                vq.TimeEnteredQueue = DateTime.Now;
                vq.VeteranApplicationUserId = userid;

                _context.VeteranQueue.Add(vq);
                _context.SaveChanges();
            }
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

        /// <summary>
        /// Action for Lawyer.
        /// </summary>
        /// <returns></returns>
        public List<VeteranLawyerMatch> GetMatches()
        {
            string userid = _userManager.GetUserId(_httpContext.User);
            List<VeteranLawyerMatch> list = _context.VeteranLawyerMatches
                .Include(match => match.Veteran.IntakeForms)
                .Include(match => match.Veteran.ApplicationUser)
                .Where(x => x.LawyerApplicationUserId == userid)
                .ToList();
            foreach(VeteranLawyerMatch match in list)
            {
                match.Veteran.IntakeForms = match.Veteran.IntakeForms
                    .Where(form => form.IsCompleted != null)
                    .Where(form => form.IsCompleted == true)
                    .Where(form => form.IsNotarized == null || form.IsNotarized == false).ToList();
            }
            return list;
        }

        /// <summary>
        /// Action for Veteran.
        /// </summary>
        /// <returns></returns>
        public VeteranLawyerMatch GetMatch()
        {
            string userid = _userManager.GetUserId(_httpContext.User);
            VeteranLawyerMatch match = _context.VeteranLawyerMatches.First(x => x.VeteranApplicationUserId == userid);
            match.Lawyer = _context.Lawyers.Find(match.LawyerApplicationUserId);
            match.Lawyer.ApplicationUser = _context.Users.Find(match.Lawyer.ApplicationUserId);
            return match;
        }

        /// <summary>
        /// Action for Veteran.
        /// </summary>
        /// <param name="lawyerId"></param>
        /// <returns></returns>
        public List<LawyerAvailability> GetLawyerAvailability(string lawyerId)
        {
            return _context.LawyerAvailability.Where(a => a.LawyerApplicationUserId == lawyerId).ToList();
        }

        /// <summary>
        /// Action for Veteran.
        /// </summary>
        /// <param name="timeId"></param>
        public void AcceptTimeSlot(int timeId)
        {
            LawyerAvailability timeSlot = _context.LawyerAvailability.Find(timeId);
            // Add timeslot to match obj
            VeteranLawyerMatch match = GetMatch();
            match.TimeSelected = timeSlot.TimeAvailable;
            match.IsDateTimeApproved = true;
            // Remove timeslot from availability obj
            _context.LawyerAvailability.Remove(timeSlot);
            _context.SaveChanges();
        }

        /// <summary>
        /// Action for Veteran.
        /// </summary>
        /// <returns></returns>
        public bool HasCompletedForm()
        {
            string userid = _userManager.GetUserId(_httpContext.User);
            return _context.VeteranIntakeForms.Any(f => f.VeteranApplicationUserId == userid) ? true : false;
        }

        public VeteranQueue GetQueueItem()
        {
            string userid = _userManager.GetUserId(_httpContext.User);
            return _context.VeteranQueue.First(v => v.VeteranApplicationUserId == userid);
            
        }

        public VeteranIntakeForm GetForm(int matchId)
        {
            string vetId = _context.VeteranLawyerMatches.FirstOrDefault(match => match.ID == matchId).VeteranApplicationUserId;
            string userId = _userManager.GetUserId(_httpContext.User);
            // Add check here to see if Lawyer is in the non-existant LawyerId property on the Form.
            var task = _context.VeteranIntakeForms
                .FirstOrDefault(form => form.VeteranApplicationUserId == vetId);
            return task;
        }
    }
}
