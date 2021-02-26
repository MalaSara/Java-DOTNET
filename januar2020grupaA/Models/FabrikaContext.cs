using Microsoft.EntityFrameworkCore;

namespace januar2020grupaA.Models{

    public class FabrikaContext:DbContext{

        public FabrikaContext(DbContextOptions options):base(options)
        {

        }

        public DbSet<Fabrika> Fabrike {get;set;}
        public DbSet<Silos> Silosi {get;set;}
    }
}