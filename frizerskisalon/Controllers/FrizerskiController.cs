using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using frizerskisalon.Models;

namespace frizerskisalon.Controllers{

    [ApiController]

    public class FrizerskiController:ControllerBase{

        private readonly FrizerskiSalonContext _db;

        public FrizerskiController(FrizerskiSalonContext db){
            _db=db;
        }

        [HttpGet]
        [Route("PreuzmiSalone")]
        public async Task<JsonResult> GetSaloniAsync(){
            var saloni=await _db.Saloni.Include(aa=>aa.Radnici).ToListAsync();
            return new JsonResult(saloni);
        }

        [HttpPost]
        [Route("DodajSalone")]
        public async Task DodajSalone(Frizerskisalon salon){
            
            _db.Saloni.Add(salon);
            await _db.SaveChangesAsync();
        }

        [HttpPost]
        [Route("DodajRadnik/{id:int}")]//id je id salona
        public async Task DodajRadnik(int id, Radnik rad){

            var sal=_db.Saloni.Find(id);
            if(sal!=null){
                
                rad.Frizerskisalon=sal;
                _db.Radnici.Add(rad);
            }
            await _db.SaveChangesAsync();
        }

        [HttpPut]
        [Route("DodajVreme/{id:int}/{vreme}")]
        public async Task DodajVreme(int id, string vreme){

            var rad=_db.Radnici.Find(id);
            if(rad!=null){
                rad.Vreme=vreme;
                _db.Radnici.Update(rad);
                await _db.SaveChangesAsync();
            }

        }

    }
}

