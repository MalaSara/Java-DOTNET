
namespace fakultetwebapp.Models{

    public class Student{

        public int Id {get;set;}

        public int Indeks {get;set;}

        public string Ime {get;set;}

        public string Prezime {get;set;}

        public Fakultet Fakultet {get;set;}
    }
}