using System.ComponentModel.DataAnnotations;

namespace apotekawebapp.Models{

    public class Lek{

        public int Id {get;set;}

        [Range(1000,9999)]
        public int RegBroj{get;set;}

        public string NazivLeka{get;set;}

        public int Cena {get;set;}

        public int Kolicina {get;set;}

        public Apoteka Apoteka {get;set;}
    }
}