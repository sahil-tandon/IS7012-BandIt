using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BandIt.Models;
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
            Bands = _context.Band.OrderBy(x => x.BandName).ToList();
        }
    }
}