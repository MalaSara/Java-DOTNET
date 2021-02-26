using Microsoft.EntityFrameworkCore;
using fakultetwebapp.Models;

namespace fakultetwebapp.Models{

    public class FakultetContext:DbContext
    {
        public FakultetContext(DbContextOptions options):base(options)
        {

        }

        public virtual DbSet<Fakultet> Fakulteti{get;set;}

        public virtual DbSet<Student> Studenti {get;set;}

    }
}