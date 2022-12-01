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
    public class AtividadesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public AtividadesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Atividades
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Atividade>>> GetAtividade()
        {
            return await _context.Atividade.ToListAsync();
        }

        // GET: api/Atividades/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Atividade>> GetAtividade(int id)
        {
            var atividade = await _context.Atividade.FindAsync(id);

            if (atividade == null)
            {
                return NotFound();
            }

            return atividade;
        }

        // PUT: api/Atividades/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAtividade(int id, Atividade atividade)
        {
            if (id != atividade.Id)
            {
                return BadRequest();
            }

            _context.Entry(atividade).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AtividadeExists(id))
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

        // POST: api/Atividades
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Atividade>> PostAtividade(Atividade atividade)
        {
            _context.Atividade.Add(atividade);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAtividade", new { id = atividade.Id }, atividade);
        }

        // DELETE: api/Atividades/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAtividade(int id)
        {
            var atividade = await _context.Atividade.FindAsync(id);
            if (atividade == null)
            {
                return NotFound();
            }

            _context.Atividade.Remove(atividade);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AtividadeExists(int id)
        {
            return _context.Atividade.Any(e => e.Id == id);
        }
    }
}
