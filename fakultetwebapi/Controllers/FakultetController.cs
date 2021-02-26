using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using fakultetwebapi.Models;

namespace fakultetwebapi.Controllers
{
    [ApiController]
    //[Route("[controller]")]
    public class FakultetController:ControllerBase{

        private readonly FakultetContext _db;
        public FakultetController(FakultetContext db)
        {
            _db=db;
        }

        [HttpGet]
        [Route("PreuzmiFakultet")]
        public async Task<JsonResult> GetFakultetiAsync()
        {
           var fakultets=await _db.Fakulteti.Include(ss=>ss.Studenti).ToListAsync();
           return new JsonResult(fakultets);
        }

        [HttpPut]
        [Route("DodajPredmet/{id:int}/{predmet}")]
        public async Task DodajPredmet(int id,string predmet)
        {

            var st=await _db.Studenti.FindAsync(id);
            if(st!=null)
            {
                st.Predmeti=predmet;
                _db.Studenti.Update(st);
                await _db.SaveChangesAsync();
            }
        }

    }
}