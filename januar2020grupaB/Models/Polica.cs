
using System.Text.Json.Serialization;

namespace januar2020grupaB.Models{

    public class Polica{
        public int Id {get;set;}

        public string Naziv {get;set;}

        public int MaksBroj{get;set;}

        public int TrenutniBroj{get;set;}

        [JsonIgnore]
        public Biblioteka Biblioteka{get;set;}
    }
}