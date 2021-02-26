
using Microsoft.EntityFrameworkCore;

namespace januar2020_bioskopi.Models{

    public class BioskopContext:DbContext{

        public BioskopContext(DbContextOptions options):base(options)
        {

        }

        public DbSet<Bioskop> Bioskopi {get;set;}

        public DbSet<Stolica> Stolice {get;set;}

    }
}