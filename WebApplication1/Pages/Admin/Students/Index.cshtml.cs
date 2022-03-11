using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using instal.Models;
using Microsoft.AspNetCore.Authorization;

namespace WebApplication1.Pages.Admin.Students
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly WebApplication1.Data.DataContext _context;

        public IndexModel(WebApplication1.Data.DataContext context)
        {
            _context = context;
        }

        public IList<Etudiant> Etudiant { get;set; }

        public async Task OnGetAsync()
        {
            Etudiant = await _context.students.ToListAsync();
        }
    }
}
