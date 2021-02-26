using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using januar2020grupaA.Models;

namespace januar2020grupaA.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FabrikaController : ControllerBase
    {
       
       private readonly FabrikaContext _db;

       public FabrikaController(FabrikaContext db){
           _db=db;
       }

       [HttpGet]
       [Route("PreuzmiFabrike")]
       public async Task<JsonResult> GetFabrikeAsync(){

           var fabrike=await _db.Fabrike.Include(f =>f.Silosi).ToListAsync();
           return new JsonResult(fabrike);
       }

       //ne kosriste se sldece dve
       [HttpPost]
       [Route("DodajFabriku")]
        public async Task DodajFabriku(Fabrika f){
           
           _db.Fabrike.Add(f);
           await _db.SaveChangesAsync();
        }

        [HttpPost]
        [Route("DodajSilos/{id:int}")]//id je id fabrike
        public async Task DodajSilos(Silos silos,int id){
            var fabrike=_db.Fabrike.Find(id);

            if(fabrike!=null){
                silos.Fabrika=fabrike;
                _db.Silosi.Add(silos);
            }
            await _db.SaveChangesAsync();
        }
       
        [HttpPost]
        [Route("DodajKapacitet/{id:int}/{kapacitet}")]//id je id silosa
        public async Task DodajKapacitet(int kapacitet,int id){

            var s=_db.Silosi.Find(id);
            if(s!=null){
                s.Kapaciteti=kapacitet;
                _db.Silosi.Update(s);
            }
            await _db.SaveChangesAsync();
        }
      
    }
}
