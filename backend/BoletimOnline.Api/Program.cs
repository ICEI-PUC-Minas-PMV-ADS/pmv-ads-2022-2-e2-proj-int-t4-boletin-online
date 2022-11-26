using Microsoft.EntityFrameworkCore;
using BoletimOnline.Api.Controllers;
using BoletimOnline.Api.Data;

var builder = WebApplication.CreateBuilder(args);

var databaseUrl = "Server=tcp:boletimonline.database.windows.net,1433;Initial Catalog=Boletim;Persist Security Info=False;User ID=thaisgurgel;Password=T@1256525897;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
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

app.UseStaticFiles();

app.MapControllers();

app.Run();
