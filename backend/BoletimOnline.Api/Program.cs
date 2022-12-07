using Microsoft.EntityFrameworkCore;
using BoletimOnline.Api.Controllers;
using BoletimOnline.Api.Data;

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

app.UseCors(x => x
    .AllowAnyMethod()
    .AllowAnyHeader()
    .SetIsOriginAllowed(origin => true) // allow any origin
    .AllowCredentials()); // allow credentials

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseStaticFiles();

app.MapControllers();

app.MapProfessorEndpoints();

app.MapDisciplinaEndpoints();

app.Run();
