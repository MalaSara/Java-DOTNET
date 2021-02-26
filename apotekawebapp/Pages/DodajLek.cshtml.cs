using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using apotekawebapp.Models;
using Microsoft.EntityFrameworkCore;

namespace MyApp.Namespace
{
    public class DodajLekModel : PageModel
    {
        private readonly ApotekaContext _db;

        [BindProperty]
        public Lek lek {get;set;}

        public int apotekaid {get;set;}

        public DodajLekModel(ApotekaContext db)
        {
            _db=db;
        }

        public void OnGet(int id)
        {
            apotekaid=id;
        }

        public async Task<ActionResult> OnPostAsync()
        {
            Apoteka apoteka=_db.Apoteke.Include(x=>x.Lekovi)
                    .Where(x=>x.Id==apotekaid).FirstOrDefault();
            
            Lek l=apoteka.Lekovi.Where(x=>x.NazivLeka==lek.NazivLeka).FirstOrDefault();
            if(l!=null){
                return Page();
            }

            lek.Apoteka=apoteka;

            _db.Lekovi.Add(lek);
            await _db.SaveChangesAsync();
            return RedirectToPage("/Index");

        }
    }
}
