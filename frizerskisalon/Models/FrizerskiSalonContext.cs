
using Microsoft.EntityFrameworkCore;

namespace frizerskisalon.Models{

    public class FrizerskiSalonContext:DbContext{

        public FrizerskiSalonContext(DbContextOptions options):base(options)
        {

        }

        public DbSet<Frizerskisalon> Saloni {get;set;}
        public DbSet<Radnik> Radnici {get;set;}
    }
}