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
    public class QuickGlanceModel : PageModel
    {
       public AppDbContext _context;

        public QuickGlanceModel(AppDbContext context) {
            _context = context;
        }
        public  ICollection<Destination> Destination { get; set; }

        public IActionResult OnGet()
        {
            Destination = _context.Destination
            .OrderBy(c=>c.Id).Include(c=>c.Country).ToList();
            return Page();
        }
    }
}