using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace WillClinic.Models
{
    public enum MaritalStatus
    {
        [Display(Name = "Married and my spouse is alive. No previous marriage")]
        Status1 = 1,
        [Display(Name = "Presently married, and had a prior marriage (previous spouse is deceased or legally divorced)")]
        Status2,
        [Display(Name = "Widow/Widower")]
        Status3,
        [Display(Name = "Single, never married")]
        Status4,
        [Display(Name = "Other")]
        status5
    }

    public enum ChildRelationToVeteran
    {
        [Display(Name = "Biological Child")]
        Status1 = 1,
        [Display(Name = "Adoptive Child")]
        Status2,
        [Display(Name = "Step-Child")]
        Status3
      
    }

    public enum InheritEstate
    {
        [Display(Name = "My Spouse")]
        Status1 = 1,
        [Display(Name = "My then living children, in equal shares")]
        Status2,
        [Display(Name = "A specific charity")]
        Status3,
        [Display(Name = "A Specific person(s)/ other")]
        Status4
    }

    public enum RemainderBeneficiary
    {
        [Display(Name = "My then living children, in equal shares")]
        Status1 = 1,
        [Display(Name = "My then living children, but if one or more of my children is deceased when I die, then his/her share un to that deceased child's children (my grandchildren)")]
        Status2,
        [Display(Name = "A specific charity")]
        Status3,
        [Display(Name = "A Specific person(s)/ other")]
        Status4
    }
}
