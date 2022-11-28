using Microsoft.EntityFrameworkCore;
using BoletimOnline.Api;
using BoletimOnline.Api.Data;
using BoletimOnline.Api.Models;
namespace BoletimOnline.Api.Controllers;

public static class DisciplinaController
{
    public static void MapDisciplinaEndpoints (this IEndpointRouteBuilder routes)
    {
        routes.MapGet("/api/Disciplina", async (ApplicationDbContext db) =>
        {
            return await db.Disciplina.ToListAsync();
        })
        .WithName("GetAllDisciplinas")
        .Produces<List<Disciplina>>(StatusCodes.Status200OK);

        routes.MapGet("/api/Disciplina/{id}", async (int Id, ApplicationDbContext db) =>
        {
            return await db.Disciplina.FindAsync(Id)
                is Disciplina model
                    ? Results.Ok(model)
                    : Results.NotFound();
        })
        .WithName("GetDisciplinaById")
        .Produces<Disciplina>(StatusCodes.Status200OK)
        .Produces(StatusCodes.Status404NotFound);

        routes.MapPut("/api/Disciplina/{id}", async (int Id, Disciplina disciplina, ApplicationDbContext db) =>
        {
            var foundModel = await db.Disciplina.FindAsync(Id);

            if (foundModel is null)
            {
                return Results.NotFound();
            }
            //update model properties here

            await db.SaveChangesAsync();

            return Results.NoContent();
        })
        .WithName("UpdateDisciplina")
        .Produces(StatusCodes.Status404NotFound)
        .Produces(StatusCodes.Status204NoContent);

        routes.MapPost("/api/Disciplina/", async (Disciplina disciplina, ApplicationDbContext db) =>
        {
            db.Disciplina.Add(disciplina);
            await db.SaveChangesAsync();
            return Results.Created($"/Disciplinas/{disciplina.Id}", disciplina);
        })
        .WithName("CreateDisciplina")
        .Produces<Disciplina>(StatusCodes.Status201Created);

        routes.MapDelete("/api/Disciplina/{id}", async (int Id, ApplicationDbContext db) =>
        {
            if (await db.Disciplina.FindAsync(Id) is Disciplina disciplina)
            {
                db.Disciplina.Remove(disciplina);
                await db.SaveChangesAsync();
                return Results.Ok(disciplina);
            }

            return Results.NotFound();
        })
        .WithName("DeleteDisciplina")
        .Produces<Disciplina>(StatusCodes.Status200OK)
        .Produces(StatusCodes.Status404NotFound);
    }
}
