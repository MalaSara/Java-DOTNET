
using System.Collections.Generic;
namespace fakultetwebapi.Models{

    public class Fakultet {

        public int Id{get;set;}

        public string Imefakulteta {get;set;}

        public string Lokacija {get;set;}

        public ICollection<Student> Studenti {get;set;}
        
    }
}