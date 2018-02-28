using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using WillClinic.Models;

namespace WillClinic.Components
{
    public class RequestLawyer : ViewComponent
    {
        public VeteranQueue Request { get; set; }
        public int Stage { get; set; }

        public void Invoke(ClaimsPrincipal user, UserManager<ApplicationUser> userManager)
        {
            switch (Stage)
            {
                case 0:
                    string userId = userManager.GetUserId(user);

                    Request = new VeteranQueue()
                    {
                        VeteranApplicationUserId = userId,
                        TimeEnteredQueue = DateTime.Now,
                    };

                    Stage++;
                    break;
                case 1:
                    //add item to service

                    Stage++;
                    break;
            }



            
        }

    }
}
