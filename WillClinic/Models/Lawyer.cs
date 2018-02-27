using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WillClinic.Models
{
    public class Lawyer
    {
        public string ApplicationUserId { get; set; }

        public ApplicationUser ApplicationUser { get; set; }

        [Required]
        public int BarNumber { get; set; }

        [StringLength(50), Required]
        public string FisrtName { get; set; }

        [StringLength(50), Required]
        public string LastName { get; set; }

        [Required]
        public DateTime DOB { get; set; }

        [StringLength(50), Required]
        public string City { get; set; }

        [StringLength(50), Required]
        public string Country { get; set; }

        [StringLength(50), Required]
        public string State { get; set; }

        [Required]
        public int ZipCode { get; set; }

        [StringLength(50), Required]
        public string EmailAddress { get; set; }

        [StringLength(50), Required]
        public string Password { get; set; }

        [StringLength(50), Required]
        public string ConfirmPassword { get; set; }

        [StringLength(50), Required]
        public string PracticeAreas { get; set; }

        public bool OtherLanguages { get; set; }
    }
}

