using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using fakultetwebapp.Models;

namespace MyApp.Namespace
{
    public class DodajFakultetModel : PageModel
    {

        private readonly FakultetContext _db;

        [BindProperty]
        public Fakultet Fakultet {get;set;}

        public DodajFakultetModel(FakultetContext db){
            _db=db;
        }
        public ActionResult OnGet()
        {
            return Page();
        }

        public async Task<ActionResult> OnPostAsync(){

            if(!ModelState.IsValid){
                return Page();
            }

            await _db.Fakulteti.AddAsync(Fakultet);
            await _db.SaveChangesAsync();
            return Redirect ("/");
        }
    }
}
