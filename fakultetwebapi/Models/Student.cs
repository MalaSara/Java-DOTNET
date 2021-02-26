
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace fakultetwebapi.Models{

    public class Student{

        public int Id {get;set;}

        public string Imestudenta {get;set;}

        public int Indeks {get;set;}

        public string Predmeti {get;set;}

        [JsonIgnore]
        public Fakultet Fakultet {get;set;}       
    }
}