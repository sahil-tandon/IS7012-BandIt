using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BandIt.Models;

namespace BandIt.Pages.Concerts
{
    public class DetailsModel : PageModel
    {
        private readonly BandIt.Models.AppDbContext _context;

        public DetailsModel(BandIt.Models.AppDbContext context)
        {
            _context = context;
        }

        public Concert Concert { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Concert = await _context.Concert
                .Include(c => c.PerformingBand).FirstOrDefaultAsync(m => m.Id == id);

            if (Concert == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
