using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using januar2020_bioskopi.Models;


namespace januar2020_bioskopi.Controllers
{
    [ApiController]
   
    public class BioskopController:ControllerBase
    {
        private readonly BioskopContext _db;

        public BioskopController(BioskopContext db){
            _db=db;
        }

        [HttpGet]
        [Route("PreuzmiBioskope")]
        public async Task<JsonResult> GetBioskopiAsync()
        {
            var bioskopi=await _db.Bioskopi.Include(b=>b.Stolice).ToListAsync();
            return new JsonResult(bioskopi);

            
        }

        [HttpPost]
        [Route("DodajStolicu/{id:int}")]
        public async Task DodajStolicu(Stolica stolica,int idbioskop){

            var bioskop=_db.Bioskopi.Find(idbioskop);

            if(bioskop!=null){
                stolica.Bioskop=bioskop;
                _db.Stolice.Update(stolica);
            }
            await _db.SaveChangesAsync();

        }


    }
}
