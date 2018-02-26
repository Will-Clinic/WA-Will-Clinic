using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WillClinic.Models
{
    public class VeteranModel
    {
        public string ApplicationUserId { get; set; }

        public ApplicationUser ApplicationUser { get; set; }

        [StringLength(50), Required]
        public string FirstName { get; set; }

        [StringLength(50), Required]
        public string MiddleInitial { get; set; }

        [StringLength(50), Required]
        public string LastName { get; set; }

        [StringLength(50), Required]
        public string Password { get; set; }

        [StringLength(50), Required]
        public string ConfirmPassword { get; set; }

        [StringLength(50), Required]
        public string Location { get; set; }

        public ICollection<VeteranChildrenModel> Children { get; set; }

        public ICollection<VeteranIntakeModel> IntakeForms { get; set; }
    }
}
