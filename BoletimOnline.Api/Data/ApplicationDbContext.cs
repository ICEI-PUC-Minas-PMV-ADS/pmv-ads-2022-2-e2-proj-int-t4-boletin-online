using BoletimOnline.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace BoletimOnline.Api.Data;

public class ApplicationDbContext : DbContext
{
    public DbSet<Student> Student { get; set; }
    
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }
}