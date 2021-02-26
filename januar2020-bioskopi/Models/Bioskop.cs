using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace januar2020_bioskopi.Models
{
    public class Bioskop
    {
        public int Id { get; set; }

        [Required]
        public string Naziv { get; set; }

        public int Red {get;set;}
        public int BrojMesta {get;set;}

        public int Rezervisanih {get;set;}

        public ICollection<Stolica> Stolice {get;set;}

    }
}