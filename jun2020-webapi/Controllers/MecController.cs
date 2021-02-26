using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using jun2020_webapi.Models;
using Microsoft.EntityFrameworkCore;

namespace jun2020_webapi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MecController : ControllerBase
    {
        private MecContext _db;

        public MecController(MecContext db){
            _db=db;
        }

        [HttpGet]
        [Route("PreuzmiMeceve")]
        public async Task<JsonResult> GetMeceveAsync()
        {
            var mec=await _db.Mecevi
                    .Include(i =>i.Igraci)
                    .ToListAsync();

            return new JsonResult(mec);
        }
    /*
        [HttpPost]
        [Route("DodajPoene/{id:int}/poeni")]
        public async Task AddPoeni(int id,int poeni)
        {
            
            var ig=_db.Igraci.FindAsync(id);
            if(ig!=null){
                ig.
            }

        }*/
    } 
}
