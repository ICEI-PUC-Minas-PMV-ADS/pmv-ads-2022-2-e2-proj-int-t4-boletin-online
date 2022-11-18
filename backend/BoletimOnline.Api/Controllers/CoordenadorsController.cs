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
    public class CoordenadorsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public CoordenadorsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Coordenadors
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Coordenador>>> GetCoordenador()
        {
            return await _context.Coordenador.ToListAsync();
        }

        // GET: api/Coordenadors/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Coordenador>> GetCoordenador(int id)
        {
            var coordenador = await _context.Coordenador.FindAsync(id);

            if (coordenador == null)
            {
                return NotFound();
            }

            return coordenador;
        }

        // PUT: api/Coordenadors/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCoordenador(int id, Coordenador coordenador)
        {
            if (id != coordenador.Id)
            {
                return BadRequest();
            }

            _context.Entry(coordenador).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CoordenadorExists(id))
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

        // POST: api/Coordenadors
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Coordenador>> PostCoordenador(Coordenador coordenador)
        {
            _context.Coordenador.Add(coordenador);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCoordenador", new { id = coordenador.Id }, coordenador);
        }

        // DELETE: api/Coordenadors/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCoordenador(int id)
        {
            var coordenador = await _context.Coordenador.FindAsync(id);
            if (coordenador == null)
            {
                return NotFound();
            }

            _context.Coordenador.Remove(coordenador);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CoordenadorExists(int id)
        {
            return _context.Coordenador.Any(e => e.Id == id);
        }
    }
}
