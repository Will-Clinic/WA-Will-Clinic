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
    //Tag helper can be used on nav or div elements
    [HtmlTargetElement("nav")]
    [HtmlTargetElement("div")]
    //Tag helper adds a class depending on user role (no class added if not logged in)
    public class ConditionalClassTagHelper : TagHelper
    {
        //Constructor for Dependency injection
        public ConditionalClassTagHelper(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        private UserManager<ApplicationUser> _userManager { get; set; }

        //String that describes the actual tag key in key-value pair
        private const string UserTheme = "user-theme";

        //Field that will hold the value of the tag helper key-value pair
        [HtmlAttributeName(UserTheme)]
        public string Id { get; set; }

        /// <summary>
        /// Method invoked when tag appears. Copies class list, will append role if one exists and add class list to output
        /// </summary>
        /// <param name="context">initial state of tag helper in DOM</param>
        /// <param name="output">html generated after tag helper is processed (includeds class based on user role)</param>
        /// <returns>void. Mutates HTML via output</returns>
        public async override Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            //Get class attribute if it exists on that html element
            var classes = context.AllAttributes.FirstOrDefault(x => x.Name == "class") ?? new TagHelperAttribute("class", "");
            //Gets rid of original class attribute
            output.Attributes.RemoveAll("class");
            //If user is not logged in, put the unmodified class attribute back
            if (Id == null || Id == "")
                output.Attributes.Add("class", classes.Value);
            //Otherwise, add in a new class corresponding to role of user
            else
            {
                ApplicationUser user = await _userManager.FindByIdAsync(Id);
                //Prioritize skins - admin, lawyer, veteran in that order
                if (await _userManager.IsInRoleAsync(user, ApplicationRoles.Admin))
                    output.Attributes.Add("class", classes.Value + " admin");
                else if (await _userManager.IsInRoleAsync(user, ApplicationRoles.Lawyer))
                    output.Attributes.Add("class", classes.Value + " lawyer");
                else if (await _userManager.IsInRoleAsync(user, ApplicationRoles.Veteran))
                    output.Attributes.Add("class", classes.Value + " veteran");
                else
                    //IF this runs something has gone wrong
                    output.Attributes.Add("class", classes.Value + " error");
            }
        }
    }
}