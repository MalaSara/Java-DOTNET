using System.Collections.Generic;

namespace apotekawebapp.Models{
    public class Apoteka{
        public int Id {get;set;}
        public string NazivApoteke {get;set;}

        public virtual ICollection<Lek> Lekovi {get;set;}
    }
}