using Microsoft.EntityFrameworkCore;

namespace apotekawebapp.Models{

    public class ApotekaContext:DbContext
    {

        public ApotekaContext(DbContextOptions options):base(options)
        {

        }

        public virtual DbSet<Apoteka> Apoteke{get;set;}

        public virtual DbSet<Lek> Lekovi{get;set;}
    }
}