using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace WillClinic.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Display(Name = "Middle Initial")]
        public string MiddleInitial { get; set; }
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
    }

    public static class ApplicationRoles
    {
        public const string Veteran = "Veteran";
        public const string Lawyer = "Lawyer";
        public const string Admin = "Admin";
    }
}
