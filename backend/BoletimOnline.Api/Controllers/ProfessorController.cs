using Microsoft.EntityFrameworkCore;
using BoletimOnline.Api;
using BoletimOnline.Api.Models;
namespace BoletimOnline.Api.Controllers;

public static class ProfessorController
{
    public static void MapProfessorEndpoints (this IEndpointRouteBuilder routes)
    {
        routes.MapGet("/api/Professor", async (ApplicationDbContext db) =>
        {
            return await db.Professor.ToListAsync();
        })
        .WithName("GetAllProfessors")
        .Produces<List<Professor>>(StatusCodes.Status200OK);

        routes.MapGet("/api/Professor/{id}", async (int Id, ApplicationDbContext db) =>
        {
            return await db.Professor.FindAsync(Id)
                is Professor model
                    ? Results.Ok(model)
                    : Results.NotFound();
        })
        .WithName("GetProfessorById")
        .Produces<Professor>(StatusCodes.Status200OK)
        .Produces(StatusCodes.Status404NotFound);

        routes.MapPut("/api/Professor/{id}", async (int Id, Professor professor, ApplicationDbContext db) =>
        {
            var foundModel = await db.Professor.FindAsync(Id);

            if (foundModel is null)
            {
                return Results.NotFound();
            }
            //update model properties here

            await db.SaveChangesAsync();

            return Results.NoContent();
        })
        .WithName("UpdateProfessor")
        .Produces(StatusCodes.Status404NotFound)
        .Produces(StatusCodes.Status204NoContent);

        routes.MapPost("/api/Professor/", async (Professor professor, ApplicationDbContext db) =>
        {
            db.Professor.Add(professor);
            await db.SaveChangesAsync();
            return Results.Created($"/Professors/{professor.Id}", professor);
        })
        .WithName("CreateProfessor")
        .Produces<Professor>(StatusCodes.Status201Created);

        routes.MapDelete("/api/Professor/{id}", async (int Id, ApplicationDbContext db) =>
        {
            if (await db.Professor.FindAsync(Id) is Professor professor)
            {
                db.Professor.Remove(professor);
                await db.SaveChangesAsync();
                return Results.Ok(professor);
            }

            return Results.NotFound();
        })
        .WithName("DeleteProfessor")
        .Produces<Professor>(StatusCodes.Status200OK)
        .Produces(StatusCodes.Status404NotFound);
    }
}
