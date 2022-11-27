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
    [Route("v1/responsibiles")]
    [ApiController]
    public class ResponsibileController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ResponsibileController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Responsibile
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Responsibile>>> GetResponsibile()
        {
          if (_context.Responsibile == null)
          {
              return NotFound();
          }
            return await _context.Responsibile.ToListAsync();
        }

        // GET: api/Responsibile/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Responsibile>> GetResponsibile(int id)
        {
          if (_context.Responsibile == null)
          {
              return NotFound();
          }
            var responsibile = await _context.Responsibile.FindAsync(id);

            if (responsibile == null)
            {
                return NotFound();
            }

            return responsibile;
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> PutStudentAsync(
            [FromServices] ApplicationDbContext context,
            [FromBody] Responsibile responsibile,
            [FromRoute] int id)
        {
            var existResponsibile = await context
                .Responsibile
                .FirstOrDefaultAsync(x => x.Id == responsibile.Id);

            if (existResponsibile == null)
                return NotFound();

            try
            {
                existResponsibile.Name = responsibile.Name;
                existResponsibile.Cpf = responsibile.Cpf;
                existResponsibile.Email = responsibile.Email;
                existResponsibile.Login = responsibile.Login;
                existResponsibile.Password = responsibile.Password;

                context.Responsibile.Update(existResponsibile);
                await context.SaveChangesAsync();
                return Ok(existResponsibile);
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }

        // POST: api/Responsibile
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Responsibile>> PostResponsibile(Responsibile responsibile)
        {
          if (_context.Responsibile == null)
          {
              return Problem("Entity set 'ApplicationDbContext.Responsibile'  is null.");
          }
            _context.Responsibile.Add(responsibile);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetResponsibile", new { id = responsibile.Id }, responsibile);
        }

        // DELETE: api/Responsibile/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteResponsibile(int id)
        {
            if (_context.Responsibile == null)
            {
                return NotFound();
            }
            var responsibile = await _context.Responsibile.FindAsync(id);
            if (responsibile == null)
            {
                return NotFound();
            }

            _context.Responsibile.Remove(responsibile);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ResponsibileExists(int id)
        {
            return (_context.Responsibile?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
