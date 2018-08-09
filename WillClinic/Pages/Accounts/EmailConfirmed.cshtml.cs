using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WillClinic.Pages.Accounts
{
    public class EmailConfirmedModel : PageModel
    {
        public IActionResult OnGet()
        {
            return Page();
        }
    }
}