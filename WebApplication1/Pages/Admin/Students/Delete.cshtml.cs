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
    public class DeleteModel : PageModel
    {
        private readonly WebApplication1.Data.DataContext _context;

        public DeleteModel(WebApplication1.Data.DataContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Etudiant Etudiant { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Etudiant = await _context.students.FirstOrDefaultAsync(m => m.id == id);

            if (Etudiant == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Etudiant = await _context.students.FindAsync(id);

            if (Etudiant != null)
            {
                _context.students.Remove(Etudiant);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
