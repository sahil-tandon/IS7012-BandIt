using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CoreCrud.Models;

namespace CoreCrud.Pages.Countries
{
    public class DeleteModel : PageModel
    {
        private readonly CoreCrud.Models.AppDbContext _context;

        public DeleteModel(CoreCrud.Models.AppDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Country Country { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Country = await _context.Country.FirstOrDefaultAsync(m => m.Id == id);

            if (Country == null)
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

            Country = await _context.Country.FindAsync(id);

            if (Country != null)
            {
                _context.Country.Remove(Country);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
