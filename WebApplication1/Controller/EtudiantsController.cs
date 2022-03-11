using instal.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;
using WebApplication1.Data;

namespace WebApplication1.Controller
{
    [Route("api/Etudiant")]
    [ApiController]
    [Produces(MediaTypeNames.Application.Json)]
    public class EtudiantsController : ControllerBase
    {
        private readonly DataContext _context;

        public EtudiantsController(DataContext context)
        {
            _context = context;
        }

        // GET: api/Etudiants
        [HttpGet]
        public List<Etudiant> GetEtudiants()
        {
            return  _context.students.ToList();
        }

        // GET: api/Etudiants/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Etudiant>> GetEtudiant(int id)
        {
            var etudiant = await _context.students.FindAsync(id);

            if (etudiant == null)
            {
                return null;
            }

            return etudiant;
        }

        // PUT: api/Etudiants/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEtudiant(int id, Etudiant etudiant)
        {
            if (id != etudiant.id)
            {
                return BadRequest();
            }

            _context.Entry(etudiant).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EtudiantExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Etudiants
        
        [HttpPost]
        public async Task<ActionResult<Etudiant>> PostEtudiant(Etudiant etudiant)
        {
            _context.students.Add(etudiant);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEtudiant", new { id = etudiant.id }, etudiant);
        }

        // DELETE: api/Etudiants/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEtudiant(int id)
        {
            var etudiant = await _context.students.FindAsync(id);
            if (etudiant == null)
            {
                return NotFound();
            }

            _context.students.Remove(etudiant);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EtudiantExists(int id)
        {
            return _context.students.Any(e => e.id == id);
        }
    }
}
