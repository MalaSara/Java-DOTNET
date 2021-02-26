using Microsoft.EntityFrameworkCore;

namespace jun2020_webapi.Models{
    public class MecContext:DbContext{

        public MecContext(DbContextOptions options):base(options){

        }

        public DbSet<Mec> Mecevi{get;set;}

        public DbSet<Igrac> Igraci {get;set;}
    }
}