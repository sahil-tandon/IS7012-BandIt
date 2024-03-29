using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BandIt.Models;

namespace BandIt.Pages.Bands
{
    public class IndexModel : PageModel
    {
        private readonly BandIt.Models.AppDbContext _context;

        public IndexModel(BandIt.Models.AppDbContext context)
        {
            _context = context;
        }

        public IList<Band> Band { get;set; }

        public async Task OnGetAsync()
        {
            Band = await _context.Band
                .Include(b => b.BandManager).ToListAsync();
        }
    }
}
