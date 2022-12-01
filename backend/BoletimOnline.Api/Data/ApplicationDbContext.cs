using BoletimOnline.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace BoletimOnline.Api.Data
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
        
        public DbSet<Responsibile> Responsibile { get; set; }
        
        public DbSet<Student> Student { get; set; }


        public DbSet<CursoDisciplina> CursoDisciplina { get; set; }


        public DbSet<Atividade> Atividade { get; set; }

    }
}
