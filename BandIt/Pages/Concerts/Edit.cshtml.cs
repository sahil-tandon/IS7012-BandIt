using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BandIt.Models;

namespace BandIt.Pages.Concerts
{
    public class EditModel : PageModel
    {
        private readonly BandIt.Models.AppDbContext _context;

        public EditModel(BandIt.Models.AppDbContext context)
        {
            _context = context;
        }

        [BindProperty]
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
           ViewData["BandID"] = new SelectList(_context.Band, "Id", "BandName");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Concert).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ConcertExists(Concert.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool ConcertExists(int id)
        {
            return _context.Concert.Any(e => e.Id == id);
        }
    }
}
