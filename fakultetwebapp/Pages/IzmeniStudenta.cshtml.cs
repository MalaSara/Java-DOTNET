using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using fakultetwebapp.Models;


namespace MyApp.Namespace
{
    public class IzmeniStudentaModel : PageModel
    {

        public readonly FakultetContext db;

        [BindProperty]
        public Student student{get;set;}

        public IzmeniStudentaModel(FakultetContext db){
            this.db=db;
        }
        public async Task<ActionResult> OnGetAsync(int id)
        {
            student=await db.Studenti.FindAsync(id);
            return Page();
        }

        public async Task<ActionResult> OnPostAsync()
        {
            if(!ModelState.IsValid){
                return Page();
            }

            db.Studenti.Update(student);
            await db.SaveChangesAsync();
            return RedirectToPage("./Index");
        }
    }
}
