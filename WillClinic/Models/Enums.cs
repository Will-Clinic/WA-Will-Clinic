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
        Status1,
        [Display(Name = "Presently married, and had a prior marriage (previous spouse is deceased or legally divorced)")]
        Status2,
        [Display(Name = "Widow/widower")]
        Status3,
        [Display(Name = "Single,nevermarried")]
        Status4
    }

    public enum ChildRelationToVeteran
    {
        [Display(Name = "Biological Child")]
        Status1,
        [Display(Name = "Adoptive Child")]
        Status2,
        [Display(Name = "Step-Child")]
        Status3
      
    }

    public enum InheritEstate
    {
        [Display(Name = "My Spouse")]
        Status1,
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
        Status1,
        [Display(Name = "Mythenlivingchildren,butifoneormoreofmychildrenisdeceasedwhenIdie,thenhis/hershareuntothatdeceasedchild'schildren(mygrandchildren)")]
        Status2,
        [Display(Name = "A specific charity")]
        Status3,
        [Display(Name = "A Specific person(s)/ other")]
        Status4
    }

    public enum UserType
    {
        [Display(Name = "Admin")]
        Status1,
        [Display(Name = "Lawyer")]
        Status2,
        [Display(Name = "Veteran")]
        Status3
    }
}
