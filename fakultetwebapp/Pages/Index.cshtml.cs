using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using fakultetwebapp.Models;
using Microsoft.EntityFrameworkCore;

namespace fakultetwebapp.Pages
{
    public class IndexModel : PageModel
    {
        
        private readonly FakultetContext _db;

        public IList<Fakultet> Fakulteti {get;set;}

        [BindProperty]
        public IList<Student> Studenti {get;set;}

        public static int StudentId {get;set;}

        public IndexModel(FakultetContext db){
            _db=db;
        }

        public async Task<ActionResult> OnGetAsync()
        {
            Fakulteti=await _db.Fakulteti.Include(s=>s.Studenti).ToListAsync();
            return Page();
        }
        /*
        public ActionResult OnPost(int id){

        }
        
        public ActionResult OnPostDodajFakultet(int id){
            return RedirectToPage("./DodajFakultet");

        }

        public ActionResult OnPostDodajStudenta(int id){
            return RedirectToPage("./DodajStudenta");
        }
        */
        public async Task<ActionResult> OnPostPovecaj(int id){
            var st=await _db.Studenti.FindAsync(id);

            if(st!=null){
                st.Indeks++;

                await _db.SaveChangesAsync();
            }
            return Redirect("/");
        }

        public async Task<ActionResult> OnPostObrisi(int id){

            var st=await _db.Studenti.FindAsync(id);
            if(st!=null)
            {
                _db.Studenti.Remove(st);
                await _db.SaveChangesAsync();
            }
            return Redirect("/");
        }
        /*
        public ActionResult OnPost(int s){
            return RedirectToPage("./IzmeniStudenta",new {id=s});
        }
        */
        
    }
}
