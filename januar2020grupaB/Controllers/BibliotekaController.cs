using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using januar2020grupaB.Models;


namespace januar2020grupaB.Controllers
{
    [ApiController]
    
    public class BibliotekaController : ControllerBase
    {
        
        private readonly BibliotekaContext _db;

        public BibliotekaController(BibliotekaContext db){
            _db=db;
        }

        [HttpGet]
        [Route("PreuzmiBiblioteku")]
        public async Task<JsonResult> GetBibliotekeAsync(){
            var biblioteke=await _db.Biblioteke.Include(b =>b.Police).ToListAsync();
            return new JsonResult(biblioteke);

        }

        [HttpPost]
        [Route("DodajKnjigu/{id:int}/{kolicina}")]
        public async Task DodajKnjigu(int kolicina,int id){

            var polica=_db.Police.Find(id);
            if(polica!=null){
                polica.TrenutniBroj+=kolicina;
                _db.Police.Update(polica);
            }

            await _db.SaveChangesAsync();
        }


        
    }
}
