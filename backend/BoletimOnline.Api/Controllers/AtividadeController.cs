using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BoletimOnline.Api.Data;
using BoletimOnline.Api.Models;
using BoletimOnline.Api.ViewModels;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;

namespace BoletimOnline.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AtividadeController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public AtividadeController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Atividade
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Atividade>>> GetAtividade()
        {
          if (_context.Atividade == null)
          {
              return NotFound();
          }
            return await _context.Atividade.ToListAsync();
        }

        // GET: api/Atividade/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Atividade>> GetAtividade(int id)
        {
          if (_context.Atividade == null)
          {
              return NotFound();
          }
          
          var atividade = _context.Atividade
              .Where(a => a.Id == id)
              .FirstOrDefault();

          if (atividade == null)
            {
                return NotFound();
            }

            return atividade;
        }

        
        [HttpGet]
        [Route("visualizarBoletim")]
        public async Task<IActionResult> GetByAtividadeAsync(
            [FromServices] ApplicationDbContext context,
            [FromQuery] int studentId,
            [FromQuery] int courseId)
        {

            var boletim = (from a in context.Atividade
                join d in context.Disciplina on a.DisciplinaId equals d.Id
                join c in context.Curso on a.CursoId equals c.Id
                join s in context.Student on a.StudentId equals s.Id
                where a.StudentId == studentId && a.CursoId == courseId
                orderby d.Nome ascending
                select new
                {
                    NameStudent = s.Name,
                    NameDisciplina = d.Nome,
                    NameCourse = c.Nome,
                    Stage = a.Etapa,
                    Note = a.Nota
                }).ToList().GroupBy(x => x.NameDisciplina);
            
            List<dynamic> BoletimviewModel = new List<dynamic>();
            
            foreach (var disciplina in boletim)
            { 
                decimal nota = 0;
                foreach (var atividade in disciplina)
                {
                    nota += atividade.Note;
           
                }
                
                BoletimviewModel.Add(new {
                    NameStudent = disciplina.FirstOrDefault()!.NameStudent,
                    NameDisciplina = disciplina.FirstOrDefault()!.NameDisciplina,
                    NameCourse = disciplina.FirstOrDefault()!.NameCourse,
                    Stage = disciplina.FirstOrDefault()!.Stage,
                    Note = Math.Round(nota /3, 2)
                });
            }
            
            return BoletimviewModel == null
                ? NotFound()
                : Ok(BoletimviewModel);
        }

        // PUT: api/Atividade/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("atualizarAtividade/{id}")]
        public async Task<IActionResult> PutAtividade(
            [FromServices] ApplicationDbContext context,
            [FromBody] AtividadeViewModels viewModel)
        {

            var atividade =  context
                .Atividade
                .Single(x => x.Id == viewModel.Id);
            
            
            if (atividade == null)
                return NotFound("Atividade não encontrada.");

           if (viewModel.Nota < 0 || viewModel.Nota > 10)
                return BadRequest("Nota não pode ser maior do que 10 ou menor do que 0.");

           if (viewModel.Etapa > 4)
                return BadRequest("Não é permitido etapa maior do que 4");
           
                try
            {
                atividade.Nota = viewModel.Nota;
                context.Atividade.Update(atividade);
                await context.SaveChangesAsync();
                return Ok(atividade);
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }
            
          
        // POST: api/Atividade
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Atividade>> PostAtividade(AtividadeViewModels atividadeViewModels,
            [FromServices] ApplicationDbContext context)
        {
          if (_context.Atividade == null)
          {
              return Problem("Entity set 'ApplicationDbContext.Atividade'  is null.");
          }
          
          var disciplina = _context.Disciplina
              .Where(d => d.Id == atividadeViewModels.DisciplinaId)
              .FirstOrDefault();
          
          var curso = _context.Curso
              .Where(c => c.Id == atividadeViewModels.CursoId)
              .FirstOrDefault();
          
          
          Atividade atividade = new Atividade();
          atividade.StudentId = atividadeViewModels.StudentId;
          atividade.Curso = curso;
          atividade.Disciplina = disciplina;
          atividade.Etapa = atividadeViewModels.Etapa;
          atividade.Nota = atividadeViewModels.Nota;
          atividade.Tipo = atividadeViewModels.Tipo;
          atividade.CursoId = atividadeViewModels.CursoId;
          atividade.DisciplinaId = atividadeViewModels.DisciplinaId;
          
          if (atividadeViewModels.Nota < 0 || atividadeViewModels.Nota > 10)
              return BadRequest("Nota não pode ser maior do que 10 ou menor do que 0.");

          if (atividadeViewModels.Etapa > 4)
              return BadRequest("Não é permitido etapa maior do que 4");

          var novaAtividade = (from a in context.Atividade
              join d in context.Disciplina on a.DisciplinaId equals d.Id
              join c in context.Curso on a.CursoId equals c.Id
              join s in context.Student on a.StudentId equals s.Id
              where a.StudentId == atividadeViewModels.StudentId && 
                    a.CursoId == atividadeViewModels.CursoId && 
                    a.DisciplinaId == atividadeViewModels.DisciplinaId &&
                    a.Etapa == atividadeViewModels.Etapa
              select new
              {
                  Disciplina = d.Id,
                  Stage = a.Etapa
              }).ToList().GroupBy(x => x.Stage);

          foreach (var x in novaAtividade)
          {
              if (x.Count() >= 3)
                  return BadRequest("Não é permitido mais do que três atividades por bimestre.");              
          }
          
              _context.Atividade.Add(atividade);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAtividade", new { id = atividade.Id }, atividade);
        }

        // DELETE: api/Atividade/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAtividade(int id)
        {
            if (_context.Atividade == null)
            {
                return NotFound();
            }
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
            return (_context.Atividade?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
