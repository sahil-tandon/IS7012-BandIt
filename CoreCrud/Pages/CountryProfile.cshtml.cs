using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using CoreCrud.Models;
using Microsoft.EntityFrameworkCore;

namespace CoreCrud.Pages
{
    public class CountryProfileModel : PageModel
    {
        private AppDbContext _context;
        
        public CountryProfileModel(AppDbContext context) {
            _context = context;
        }

        public Country Country { get; set; }

        public IActionResult OnGet(int? id)
        {
            if(id==null){
                return NotFound();
            }

            Country = _context.Country
                              .Include(c=>c.Destination).FirstOrDefault(c=>c.Id==id);

            if(Country == null){
                return NotFound();
            }

            return Page();
        }
    }
}