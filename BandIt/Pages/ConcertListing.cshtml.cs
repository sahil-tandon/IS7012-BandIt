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
            SearchCompleted = false;
            Concerts = _context.Concert.OrderBy(x => x.Date).Include(x => x.PerformingBand).ToList();
        }
        [BindProperty]
        public string ConcertSearch { get; set; }
        public bool SearchCompleted { get; set; }
        public ICollection<Concert> SearchResults { get; set; }

        public void OnPost() {
            // PERFORM SEARCH
            if (string.IsNullOrWhiteSpace(ConcertSearch)) {
                SearchResults = _context.Concert.OrderBy(x => x.Date).Include(x => x.PerformingBand).ToList();
                SearchCompleted = true;
            }
            else{
                SearchResults = _context.Concert
                                    .Include(x => x.PerformingBand)
                                    .Where(x => x.PerformingBand.BandName.ToLower().Contains(ConcertSearch.ToLower()))
                                    .ToList();
                SearchCompleted = true;
            }
        }
    }
}