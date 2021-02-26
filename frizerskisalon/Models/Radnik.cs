
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

namespace frizerskisalon.Models{

    public class Radnik{

        public int Id {get;set;}

        public string Imeradnik {get;set;}

        public string Vreme {get;set;}

        [JsonIgnore]
        public Frizerskisalon Frizerskisalon {get;set;}

    }
}