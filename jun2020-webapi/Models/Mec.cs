using System.Collections.Generic;

namespace jun2020_webapi.Models{

    public class Mec{
        public int Id{get;set;}

        public string Lokacija{get;set;}

        public string Listapoena{get;set;}

        public string Vreme {get;set;}

        public ICollection<Igrac> Igraci {get;set;}
    }
}