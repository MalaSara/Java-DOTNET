using System.Text.Json.Serialization;

namespace januar2020grupaA.Models{

    public class Silos{
        public int Id {get;set;}

        public int Kapaciteti {get;set;}

        [JsonIgnore]
        public Fabrika Fabrika  {get;set;}
    }
}