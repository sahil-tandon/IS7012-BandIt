using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BandIt.Models;

namespace BandIt.Pages.Managers
{
    public class IndexModel : PageModel
    {
        private readonly BandIt.Models.AppDbContext _context;

        public IndexModel(BandIt.Models.AppDbContext context)
        {
            _context = context;
        }

        public IList<Manager> Manager { get;set; }

        public async Task OnGetAsync()
        {
            Manager = await _context.Manager.ToListAsync();
        }
    }
}
