using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BandIt.Models;

namespace BandIt.Pages.Songs
{
    public class IndexModel : PageModel
    {
        private readonly BandIt.Models.AppDbContext _context;

        public IndexModel(BandIt.Models.AppDbContext context)
        {
            _context = context;
        }

        public IList<Song> Song { get;set; }

        public async Task OnGetAsync()
        {
            Song = await _context.Song
                .Include(s => s.Artist).ToListAsync();
        }
    }
}
