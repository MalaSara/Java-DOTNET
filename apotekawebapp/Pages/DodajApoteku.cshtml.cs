using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using apotekawebapp.Models;

namespace MyApp.Namespace
{
    public class DodajApotekuModel : PageModel
    {
        
        private readonly ApotekaContext _db;

        [BindProperty]
        public Apoteka Apoteka {get;set;}

        public DodajApotekuModel(ApotekaContext db){
            _db=db;
        }

        public ActionResult OnGet()
        {
            return Page();
        }

        public async Task<ActionResult> OnPostAsync()
        {
        
            await _db.Apoteke.AddAsync(Apoteka);
            await _db.SaveChangesAsync();

            return Redirect("/");
        }
    }
}
