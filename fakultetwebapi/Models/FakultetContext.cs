
using Microsoft.EntityFrameworkCore;

namespace fakultetwebapi.Models{

    public class FakultetContext:DbContext
    {
        public FakultetContext(DbContextOptions options):base(options)
        {

        }

        public DbSet<Fakultet> Fakulteti {get;set;}

        public DbSet<Student> Studenti {get;set;}

    }
}