using Microsoft.EntityFrameworkCore;

namespace BoletimOnline.Api
{
    public class ApplicationDbContext : DbContext
    {


        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)

            : base(options)
        {



        }


    }
}
