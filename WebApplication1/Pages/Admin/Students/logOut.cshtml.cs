using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApplication1.Pages.Admin.Students
{
    public class logOutModel : PageModel
    {
        public async Task OnGetAsync()
        {
            await HttpContext.SignOutAsync();
            Response.Redirect("/admin");
        }
    }
}
