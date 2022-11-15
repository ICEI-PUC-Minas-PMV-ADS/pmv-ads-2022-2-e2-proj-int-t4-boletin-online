using BoletimOnline.Api;
using Microsoft.EntityFrameworkCore;
using BoletimOnline.Api.Controllers;

var builder = WebApplication.CreateBuilder(args);

var databaseUrl = "server=127.0.0.1;Database=Boletim;User Id=sa;Password=Secret1256;";
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(databaseUrl));

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MapProfessorEndpoints();

app.MapCursoEndpoints();

app.MapDisciplinaEndpoints();

app.Run();
