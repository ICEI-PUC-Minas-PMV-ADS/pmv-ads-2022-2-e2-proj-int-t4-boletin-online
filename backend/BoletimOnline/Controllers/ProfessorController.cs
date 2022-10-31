using BoletimOnline.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BoletimOnline.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfessorController : ControllerBase
    {
        // GET: api/<ProfessorController>
        [HttpGet]
        public List<Professor> BuscarProfessor([FromServices] ApplicationDbContext context)
        {
            var professor = context.Professor.AsNoTracking().ToList();

            return professor == null ? new List<Professor>() : professor;

        }

        // GET api/<ProfessorController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> BuscarProfessorPorId(
            [FromServices] ApplicationDbContext context, 
            [FromRoute] int id
            )
        {
            var professor = await context.Professor
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id);

            return professor == null
                ? NotFound()
                : Ok(professor);
        }

        // GET api/<ProfessorSemComenterio/

        [HttpGet]
        [Route("professor/nome")]
        public async Task<IActionResult> BuscarProfessorNome(
            [FromServices] ApplicationDbContext context,
            [FromQuery] string nome)
            
        {
            var professor = context
                .Professor
                .Where(x => EF.Functions.Like(x.Nome, $"%{nome}%"))
                .ToList();

            return professor == null
                ? NotFound()
                : Ok(professor);
        }


        // POST api/<ProfessorController>
        [HttpPost]
        public async Task<IActionResult> InserirProfessor(
            [FromServices] ApplicationDbContext context,
            [FromBody] Professor novoprofessor)
        {
        
            if (!ModelState.IsValid)
                return BadRequest();

            try
            {

                await context.Professor.AddAsync(novoprofessor);
                await context.SaveChangesAsync();
                return Created($"v1/student/{novoprofessor.Id}", novoprofessor);

            }

            catch (Exception e) 
            {             
            
                return BadRequest();

            }

            
        }

        // PUT api/<ProfessorController>/
        [HttpPut()]
        public async Task<IActionResult> AtualizarProfessor(

            [FromServices] ApplicationDbContext context,            
            [FromBody] Professor viewModel)
               
        {
        
            var professor = await context
                .Professor.AsNoTracking().FirstOrDefaultAsync(x => x.Id == viewModel.Id);
        
            if (professor == null)
                return NotFound();

            try 
            
            {

                professor.Nome = viewModel.Nome;
                professor.Cpf = viewModel.Cpf;
                professor.Email = viewModel.Email;

                context.Professor.Update(professor);
                await context.SaveChangesAsync();
                return Ok(professor);

            
            }

            catch (Exception e)
            {

                return BadRequest();

            }

        }

       
       
    }
}
