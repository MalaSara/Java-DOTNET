using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace januar2020grupaA.Models{

    public class Fabrika{
        public int Id{get;set;}
        [Required]
        public string Naziv{get;set;}

        public ICollection<Silos> Silosi{get;set;}
    }
}