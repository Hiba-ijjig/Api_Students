using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebApplication1.Data;
using instal.Models;
using Microsoft.AspNetCore.Authorization;

namespace WebApplication1.Pages.Admin.Students
{
    [Authorize]
    public class CreateModel : PageModel
    {
        private readonly WebApplication1.Data.DataContext _context;

        public CreateModel(WebApplication1.Data.DataContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Etudiant Etudiant { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.students.Add(Etudiant);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
