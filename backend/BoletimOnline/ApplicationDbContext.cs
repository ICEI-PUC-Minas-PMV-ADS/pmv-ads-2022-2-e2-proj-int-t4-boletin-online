using BoletimOnline.Models;
using Microsoft.EntityFrameworkCore;


namespace BoletimOnline
{
    public class ApplicationDbContext : DbContext
    {

     public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)

            : base(options)
        {

        }

        public DbSet<Curso> Curso { get; set; }
        public DbSet<Disciplina> Disciplina { get; set; }
        public DbSet<Professor> Professor { get; set; }


    }

   
}



