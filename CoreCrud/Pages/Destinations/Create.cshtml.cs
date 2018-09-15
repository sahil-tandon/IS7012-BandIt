using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using CoreCrud.Models;

namespace CoreCrud.Pages.Destinations
{
    public class CreateModel : PageModel
    {
        private readonly CoreCrud.Models.AppDbContext _context;

        public CreateModel(CoreCrud.Models.AppDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["CountryID"] = new SelectList(_context.Country, "Id", "Id");
            return Page();
        }

        [BindProperty]
        public Destination Destination { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Destination.Add(Destination);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}