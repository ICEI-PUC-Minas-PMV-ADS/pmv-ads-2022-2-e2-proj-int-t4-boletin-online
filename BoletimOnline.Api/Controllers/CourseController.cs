using System.ComponentModel.DataAnnotations;
using BoletimOnline.Api.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BoletimOnline.Api.Controllers;

    [ApiController]
    [Route(template:"v1")]
    public class CourseController  : ControllerBase
    {
        [HttpGet]
        [Route("courses")]
        public async Task<IActionResult> GetAllAsync(
            [FromServices] ApplicationDbContext context)
        {
            var course =  context
                .Course
                .AsNoTracking().ToList();
                

            return course == null
                ? NotFound()
                : Ok(course);
        }
        
        [HttpGet]
        [Route("courses/{id}")]
        public async Task<IActionResult> GetByIdAsync(
            [FromServices] ApplicationDbContext context,
            [FromRoute] int id)
        {
            var course = await context
                .Course
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id);

            return course == null
                ? NotFound()
                : Ok(course);
        }

        
    }

