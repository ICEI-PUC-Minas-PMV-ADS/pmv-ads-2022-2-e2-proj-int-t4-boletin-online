using Microsoft.EntityFrameworkCore;
using BoletimOnline.Api;
using BoletimOnline.Api.Models;
namespace BoletimOnline.Api.Controllers;

public static class CursoController
{
    public static void MapCursoEndpoints (this IEndpointRouteBuilder routes)
    {
        routes.MapGet("/api/Curso", async (ApplicationDbContext db) =>
        {
            return await db.Curso.ToListAsync();
        })
        .WithName("GetAllCursos")
        .Produces<List<Curso>>(StatusCodes.Status200OK);

        routes.MapGet("/api/Curso/{id}", async (int Id, ApplicationDbContext db) =>
        {
            return await db.Curso.FindAsync(Id)
                is Curso model
                    ? Results.Ok(model)
                    : Results.NotFound();
        })
        .WithName("GetCursoById")
        .Produces<Curso>(StatusCodes.Status200OK)
        .Produces(StatusCodes.Status404NotFound);

        routes.MapPut("/api/Curso/{id}", async (int Id, Curso curso, ApplicationDbContext db) =>
        {
            var foundModel = await db.Curso.FindAsync(Id);

            if (foundModel is null)
            {
                return Results.NotFound();
            }
            //update model properties here

            await db.SaveChangesAsync();

            return Results.NoContent();
        })
        .WithName("UpdateCurso")
        .Produces(StatusCodes.Status404NotFound)
        .Produces(StatusCodes.Status204NoContent);

        routes.MapPost("/api/Curso/", async (Curso curso, ApplicationDbContext db) =>
        {
            db.Curso.Add(curso);
            await db.SaveChangesAsync();
            return Results.Created($"/Cursos/{curso.Id}", curso);
        })
        .WithName("CreateCurso")
        .Produces<Curso>(StatusCodes.Status201Created);

        routes.MapDelete("/api/Curso/{id}", async (int Id, ApplicationDbContext db) =>
        {
            if (await db.Curso.FindAsync(Id) is Curso curso)
            {
                db.Curso.Remove(curso);
                await db.SaveChangesAsync();
                return Results.Ok(curso);
            }

            return Results.NotFound();
        })
        .WithName("DeleteCurso")
        .Produces<Curso>(StatusCodes.Status200OK)
        .Produces(StatusCodes.Status404NotFound);
    }
}
