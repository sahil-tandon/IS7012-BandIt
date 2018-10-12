using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BandIt.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace BandIt.Pages
{
    public class SongListingModel : PageModel
    {
        public AppDbContext _context;
        public SongListingModel(AppDbContext context){
            _context = context;
        }

        public  ICollection<Song> Songs { get; set; }

        public IActionResult OnGet(int? id)
        {
            if(id==null){
                Songs = _context.Song
                    .OrderBy(x=>x.Title).Include(x => x.Artist).ToList();
            }   
            else {
            Songs = _context.Song
                    .OrderBy(x=>x.Title).Where(x => x.Artist.Id == id).Include(x => x.Artist).ToList();
            }

            if(Songs==null){
                return NotFound();
            }

            return Page();
        }
    }
}