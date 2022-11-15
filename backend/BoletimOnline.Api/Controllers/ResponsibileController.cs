using System.ComponentModel.DataAnnotations;
using BoletimOnline.Api.Data;
using BoletimOnline.Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BoletimOnline.Api.Controllers;

[ApiController]
[Route(template:"v1")]
public class ResponsibileController  : ControllerBase
{
        
    [HttpPost]
    [Route(template:"responsibiles")]
    public async Task<IActionResult> PostNewResponsibileAsync(
        [FromServices] ApplicationDbContext context,
        [FromBody] Responsibile newResponsibile)
    {
        if (!ModelState.IsValid)
            return BadRequest();

        var responsibile = new Responsibile(newResponsibile.Name, newResponsibile.Cpf, newResponsibile.Email);
            
        try
        {
            await context.Responsibile.AddAsync(responsibile);
            await context.SaveChangesAsync();
            return Created($"v1/responsibile/{responsibile.Id}", responsibile);
        }
        catch (Exception e)
        {
            return BadRequest();
        }
    }
}