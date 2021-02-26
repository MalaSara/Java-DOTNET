
using System.Collections.Generic;

namespace frizerskisalon.Models{

    public class Frizerskisalon{

        public int Id{get;set;}

        public string Imesalona {get;set;}

        public string Lokacija {get;set;}

        public ICollection<Radnik> Radnici {get;set;}
    }
}