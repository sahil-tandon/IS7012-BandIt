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
    public class DeleteModel : PageModel
    {
        private readonly BandIt.Models.AppDbContext _context;

        public DeleteModel(BandIt.Models.AppDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Band Band { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Band = await _context.Band
                .Include(b => b.BandManager).FirstOrDefaultAsync(m => m.Id == id);

            if (Band == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Band = await _context.Band.FindAsync(id);

            if (Band != null)
            {
                _context.Band.Remove(Band);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
