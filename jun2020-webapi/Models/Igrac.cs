
namespace jun2020_webapi.Models{

    public class Igrac{
        public int Id {get;set; }

        public string Ime { get; set; }

        public int Godine { get; set; }

        public int Atprang{ get;set;} 

        public int Poeni {get;set;} 

        public Mec Mec {get;set;}

    }
}