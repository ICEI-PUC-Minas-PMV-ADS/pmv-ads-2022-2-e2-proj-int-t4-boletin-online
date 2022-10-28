using System.ComponentModel.DataAnnotations;
using BoletimOnline.Api.Data;
using BoletimOnline.Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BoletimOnline.Api.Controllers;

    [ApiController]
    [Route(template:"v1")]
    public class StudentController  : ControllerBase
    {
        [HttpGet]
        [Route("students")]
        public async Task<IActionResult> GetAllAsync(
            [FromServices] ApplicationDbContext context)
        {
            var student =  context
                .Student
                .AsNoTracking().ToList();
                

            return student == null
                ? NotFound()
                : Ok(student);
        }
        
        [HttpGet]
        [Route("students/{id}")]
        public async Task<IActionResult> GetStudentByIdAsync(
            [FromServices] ApplicationDbContext context,
            [FromRoute] int id)
        {
            var student = await context
                .Student
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id);

            return student == null
                ? NotFound()
                : Ok(student);
        }

        [HttpPut]
        [Route("students")]
        public async Task<IActionResult> PutStudentAsync(
            [FromServices] ApplicationDbContext context,
            [FromBody] Student viewModel)
        {
            var student = await context
                .Student
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == viewModel.Id);

            if (student == null)
                return NotFound();

            try
            {
                student.Name = viewModel.Name;
                student.IdResponsibile = viewModel.IdResponsibile;
                student.Enrollment = viewModel.Enrollment;
                student.IdCourse = viewModel.IdCourse;

                context.Student.Update(student);
                await context.SaveChangesAsync();
                return Ok(student);
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }
        
        [HttpPost]
        [Route(template:"students")]
        public async Task<IActionResult> PostNewStudentAsync(
            [FromServices] ApplicationDbContext context,
            [FromBody] Student newStudent)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var student = new Student(newStudent.IdResponsibile, newStudent.Enrollment, newStudent.Name, newStudent.IdCourse);
            
            try
            {
                await context.Student.AddAsync(student);
                await context.SaveChangesAsync();
                return Created($"v1/student/{student.Id}", student);
            }
            catch (Exception e)
            {
                return BadRequest();
            }



        }
        
    }

