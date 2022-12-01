using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BoletimOnline.Api.Data;
using BoletimOnline.Api.Models;

namespace BoletimOnline.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DisciplinaController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public DisciplinaController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Disciplina
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Disciplina>>> GetDisciplina()
        {
          if (_context.Disciplina == null)
          {
              return NotFound();
          }
            return await _context.Disciplina.ToListAsync();
        }

        // GET: api/Disciplina/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Disciplina>> GetDisciplina(int id)
        {
          if (_context.Disciplina == null)
          {
              return NotFound();
          }
            var disciplina = await _context.Disciplina.FindAsync(id);

            if (disciplina == null)
            {
                return NotFound();
            }

            return disciplina;
        }

        // PUT: api/Disciplina/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDisciplina(int id, Disciplina disciplina)
        {
            if (id != disciplina.Id)
            {
                return BadRequest();
            }

            _context.Entry(disciplina).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DisciplinaExists(id))
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

        // POST: api/Disciplina
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Disciplina>> PostDisciplina(Disciplina disciplina)
        {
          if (_context.Disciplina == null)
          {
              return Problem("Entity set 'ApplicationDbContext.Disciplina'  is null.");
          }
            _context.Disciplina.Add(disciplina);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDisciplina", new { id = disciplina.Id }, disciplina);
        }

        // DELETE: api/Disciplina/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDisciplina(int id)
        {
            if (_context.Disciplina == null)
            {
                return NotFound();
            }
            var disciplina = await _context.Disciplina.FindAsync(id);
            if (disciplina == null)
            {
                return NotFound();
            }

            _context.Disciplina.Remove(disciplina);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DisciplinaExists(int id)
        {
            return (_context.Disciplina?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
