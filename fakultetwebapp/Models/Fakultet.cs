using System.Collections.Generic;

namespace fakultetwebapp.Models{

    public class Fakultet{

        public int Id {get;set;}

        public string NazivFaksa {get;set;}

        public virtual ICollection<Student> Studenti {get;set;}
    }
}