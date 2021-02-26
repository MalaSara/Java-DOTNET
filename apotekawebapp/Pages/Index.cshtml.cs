using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using apotekawebapp.Models;
using Microsoft.EntityFrameworkCore;



namespace apotekawebapp.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ApotekaContext _db;

        [BindProperty]
        public IList<Lek> Lekovi {get;set;}

        [BindProperty]
        public IList<Apoteka> Apoteke {get;set;}

        public static int lekid {get;set;}

        public IndexModel(ApotekaContext db){
            _db=db;
        }

        public async Task<ActionResult> OnGetAync()
        {
            Apoteke=await _db.Apoteke.Include(z=>z.Lekovi).ToListAsync();
            return Page();
        }

        public async Task<ActionResult> OnPostPovecaj(int id){
            
            var lekic=await _db.Lekovi.FindAsync(id);

            if(lekic!=null){
                lekic.Kolicina++;

                await _db.SaveChangesAsync();
            }

            return Redirect("/");
        }

        public async Task<ActionResult> OnPostSmanji(int id){
            
            var lekic=await _db.Lekovi.FindAsync(id);

            if(lekic!=null){
                lekic.Kolicina--;

                await _db.SaveChangesAsync();
            }

            return Redirect("/");
        }

        public async Task<ActionResult> OnPostObrisiLek(int id){

            var lekic=await _db.Lekovi.FindAsync(id);
            if(lekic!=null)
            {
                _db.Lekovi.Remove(lekic);
                await _db.SaveChangesAsync();
            }
            return Redirect("/");
        }
    }
}
