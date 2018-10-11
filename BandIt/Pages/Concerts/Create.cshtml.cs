using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BandIt.Models;

namespace BandIt.Pages.Concerts
{
    public class CreateModel : PageModel
    {
        private readonly BandIt.Models.AppDbContext _context;

        public CreateModel(BandIt.Models.AppDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["BandID"] = new SelectList(_context.Band, "Id", "BandName");
            return Page();
        }

        [BindProperty]
        public Concert Concert { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Concert.Add(Concert);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}