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
        [Route("students/course")]
        public async Task<IActionResult> GetByCourseAsync(
            [FromServices] ApplicationDbContext context,
            [FromQuery] int course)
        {
            var student =  context
                .Student
                .Where(x => x.IdCourse == course)
                .ToList();
                

            return student == null
                ? NotFound()
                : Ok(student);
        }
        
        [HttpGet]
        [Route("students/search")]
        public async Task<IActionResult> GetByNameAsync(
            [FromServices] ApplicationDbContext context,
            [FromQuery] string name,
            [FromQuery] int course)
        {
            var student =  context
                .Student
                .Where(x => EF.Functions.Like(x.Name, $"%{name}%"))
                .Where(x => x.IdCourse == course)
                .ToList();
         
            return student == null
                ? NotFound()
                : Ok(student);
        }
        
        [HttpGet]
        [Route("students")]
        public async Task<IActionResult> GetAllAsync(
            [FromServices] ApplicationDbContext context)
        {
            var student =  context.Student.ToList();
                
            return student == null
                ? NotFound()
                : Ok(student);
        }
        
        [HttpGet]
        [Route("students/id")]
        public async Task<IActionResult> GetStudentByIdAsync(
            [FromServices] ApplicationDbContext context,
            [FromQuery] int id)
        {
            var student = await context
                .Student
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

