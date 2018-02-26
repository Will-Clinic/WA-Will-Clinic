using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace WillClinic.Models
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        
        public string LastName { get; set; }
        
        public string EmailAddress { get; set; }

        // One of "admin", "lawyer", or "veteran".
        public string UserType { get; set; }
        
    }

    public static class ApplicationRoles
    {
        public const string Veteran = "Veteran";
        public const string Lawyer = "Lawyer";
        public const string Admin = "Admin";
        
    }
}
