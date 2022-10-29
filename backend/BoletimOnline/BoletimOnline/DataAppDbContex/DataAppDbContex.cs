using Microsoft.EntityFrameworkCore;

namespace BoletimOnline.Data
{
    public class  : DbContext
    {
        public DbSet<PaginaLogin> PaginaLogin { get; set; }
    protected override void onConfiguring(
        DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseSqlServer(connectionString: "DataSource=app.db;Cache=Shared"); }
    }
