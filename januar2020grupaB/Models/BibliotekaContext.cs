using Microsoft.EntityFrameworkCore;

namespace januar2020grupaB.Models{

    public class BibliotekaContext:DbContext{

        public BibliotekaContext(DbContextOptions options):base(options){

        }
        public DbSet<Biblioteka> Biblioteke {get;set;}

        public DbSet<Polica> Police {get;set;}
    }
}