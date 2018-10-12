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
    public class BandListingModel : PageModel
    {        
        private AppDbContext _context;        
        public BandListingModel(AppDbContext context) {
            _context = context;
        }
        public ICollection<Band> Bands { get; set; }
        public void OnGet()
        {
            SearchCompleted = false;
            
            Bands = _context.Band.OrderBy(x => x.BandName).Include(x => x.BandManager).ToList();
        }


        [BindProperty]
        public string Search { get; set; }
        public bool SearchCompleted { get; set; }
        public ICollection<Band> SearchResults { get; set; }
        
        public void OnPost() {
            // PERFORM SEARCH
            if (string.IsNullOrWhiteSpace(Search)) {
                SearchResults =  _context.Band.OrderBy(x => x.BandName).Include(x => x.BandManager).ToList();
                SearchCompleted = true;
            }
            else{
                SearchResults = _context.Band
                                    .Include(x => x.BandManager)
                                    .Where(x => x.BandName.ToLower().Contains(Search.ToLower()))
                                    .ToList();
                SearchCompleted = true;
            }
        }
    }
}
