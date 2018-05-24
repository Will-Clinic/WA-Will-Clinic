using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WillClinic.Models;

namespace WillClinic
{
    [HtmlTargetElement("nav")]
    [HtmlTargetElement("div")]
    public class ConditionClassTagHelper : TagHelper
    {
        public ConditionClassTagHelper(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        private const string UserTheme = "user-theme";

        private UserManager<ApplicationUser> _userManager { get; set; }

        [HtmlAttributeName(UserTheme)]
        public string Id { get; set; }

        public async override Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            var classes = context.AllAttributes.FirstOrDefault(x => x.Name == "class") ?? new TagHelperAttribute("class", "");
            output.Attributes.RemoveAll("class");
            if (Id == null || Id == "")
                output.Attributes.Add("class", classes.Value);
            else
            {
                ApplicationUser user = await _userManager.FindByIdAsync(Id);
                if (await _userManager.IsInRoleAsync(user, ApplicationRoles.Admin))
                    output.Attributes.Add("class", classes.Value + " admin");
                else if (await _userManager.IsInRoleAsync(user, ApplicationRoles.Veteran))
                    output.Attributes.Add("class", classes.Value + " veteran");
                else if (await _userManager.IsInRoleAsync(user, ApplicationRoles.Lawyer))
                    output.Attributes.Add("class", classes.Value + " lawyer");
                else
                    output.Attributes.Add("class", classes.Value + " error");
            }
        }
    }
}