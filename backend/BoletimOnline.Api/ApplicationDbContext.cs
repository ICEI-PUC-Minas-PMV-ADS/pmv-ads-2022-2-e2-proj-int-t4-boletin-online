using BoletimOnline.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace BoletimOnline.Api
{
    public class ApplicationDbContext : DbContext
    {


        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)

            : base(options)
        {
        }
        
        public DbSet<Professor> Professor { get; set; }

        public DbSet<Disciplina> Disciplina { get; set; }

        public DbSet<Curso> Curso { get; set; }

    
    }
}
