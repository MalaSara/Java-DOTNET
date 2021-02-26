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
    public class IzmeniLekModel : PageModel
    {
        private readonly ApotekaContext _db;

        [BindProperty]
        public Lek lek {get;set;}


        public IzmeniLekModel(ApotekaContext db)
        {
            _db=db;
        }

         public async Task<ActionResult> OnGetAsync(int id)
        {
            lek=await _db.Lekovi.FindAsync(id);
            return Page();
        }

     
        public async Task<ActionResult> OnPostAsync()
        {
            
            _db.Lekovi.Update(lek);
            await _db.SaveChangesAsync();
            return RedirectToPage("./Index");

        }
    }
}
