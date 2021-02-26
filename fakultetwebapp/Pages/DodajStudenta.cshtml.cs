using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using fakultetwebapp.Models;
using Microsoft.EntityFrameworkCore;

namespace MyApp.Namespace
{
    public class DodajStudentaModel : PageModel
    {

        private readonly FakultetContext _db;

        [BindProperty]
        public Student student{get;set;}

        [BindProperty]
        public int faksid{get;set;}

        public DodajStudentaModel(FakultetContext db){
            _db=db;
        }
        public void OnGet(int id)
        {
           faksid=id;
            //return Page();
        }

        public async Task<ActionResult> OnPostAsync()
        {
            if(!ModelState.IsValid)
            {
                 return Page();
                

            } 
            else
            {
               Fakultet fakultet=_db.Fakulteti.Include(x=>x.Studenti)
                        .Where(x=>x.Id ==faksid).FirstOrDefault();
                
                Student s=fakultet.Studenti.Where(x=>x.Ime==student.Ime).FirstOrDefault();//ako postoji
                if(s!=null){
                    return Page();
                }

                student.Fakultet=fakultet;

                _db.Studenti.Add(student);
                await _db.SaveChangesAsync();

                return RedirectToPage("/Index");
            }
        }
    }
}
