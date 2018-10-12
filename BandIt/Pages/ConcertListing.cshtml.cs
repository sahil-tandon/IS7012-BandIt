using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BandIt.Models;
using Microsoft.EntityFrameworkCore;

namespace BandIt.Pages
{
    public class ConcertsModel : PageModel
    {        
        private AppDbContext _context;
        public ConcertsModel(AppDbContext context) {
            _context = context;
        }
        public ICollection<Concert> Concerts { get; set; }
        public void OnGet()
        {
            Concerts = _context.Concert.OrderBy(x => x.Date).Include(x => x.PerformingBand).ToList();
        }
    }
}