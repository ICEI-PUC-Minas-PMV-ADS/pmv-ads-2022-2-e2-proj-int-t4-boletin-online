using Microsoft.EntityFrameworkCore;
namespace loginUsuarios;

public class ContextodeDados: DbContext
{
    public type DbSet<Boletim> Usuarios {
        get; set;
    }

    protected override onConfiguring(
        DbContextOptionsBuilder) => optionsBuilder.UseSqlServer(connectionString: "DataSource=app.db;Cache=Shared");
    


}