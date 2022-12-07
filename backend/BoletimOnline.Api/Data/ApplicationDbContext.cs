using BoletimOnline.Api.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;

namespace BoletimOnline.Api.Data
{
    public class ApplicationDbContext : DbContext
    {


        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)

            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }

        public DbSet<Professor> Professor { get; set; }

        public DbSet<Disciplina> Disciplina { get; set; }

        public DbSet<Curso> Curso { get; set; }
        
        public DbSet<Responsibile> Responsibile { get; set; }
        
        public DbSet<Student> Student { get; set; }

        public DbSet<Coordenador> Coordenador { get; set; }

        public DbSet<Nota> Nota { get; set; }


    }
}
