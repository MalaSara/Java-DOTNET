//    constructor(id,nazivpolice,maksbroj,trenutnibroj){
using System.Collections.Generic;

namespace januar2020grupaB.Models
{
    public class Biblioteka
    {
        public int Id {get;set;}

        public string Naziv{get;set;}

        public ICollection<Polica> Police {get;set;}
    }
}