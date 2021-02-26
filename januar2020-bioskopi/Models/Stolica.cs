

using System.Text.Json.Serialization;

namespace januar2020_bioskopi.Models{

    public class Stolica{

        public int Id { get; set; }

        [JsonIgnore]
        public  Bioskop Bioskop {get;set;}
    }
}