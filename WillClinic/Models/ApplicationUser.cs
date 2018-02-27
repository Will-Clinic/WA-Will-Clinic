using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace WillClinic.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string MiddleInitial { get; set; }
        public string LastName { get; set; }
    }

    public static class ApplicationRoles
    {
        public const string Veteran = "Veteran";
        public const string Lawyer = "Lawyer";
        public const string Admin = "Admin";
    }
}
