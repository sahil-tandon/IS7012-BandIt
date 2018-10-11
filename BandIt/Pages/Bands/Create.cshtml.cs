using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BandIt.Models;

namespace BandIt.Pages.Bands
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
        ViewData["ManagerID"] = new SelectList(_context.Manager, "Id", "ManagerName");
            return Page();
        }

        [BindProperty]
        public Band Band { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Band.Add(Band);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}