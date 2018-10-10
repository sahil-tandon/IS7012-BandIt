using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BandIt.Models;

namespace BandIt.Pages.Bands
{
    public class EditModel : PageModel
    {
        private readonly BandIt.Models.AppDbContext _context;

        public EditModel(BandIt.Models.AppDbContext context)
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

            Band = await _context.Band.FirstOrDefaultAsync(m => m.Id == id);

            if (Band == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Band).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BandExists(Band.Id))
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

        private bool BandExists(int id)
        {
            return _context.Band.Any(e => e.Id == id);
        }
    }
}
