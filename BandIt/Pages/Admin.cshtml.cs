using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BandIt.Models;
using Microsoft.EntityFrameworkCore;

namespace BandIt.Pages
{
    public class AdminModel : PageModel
    {
        private AppDbContext _context;
        public AdminModel(AppDbContext context) {
            _context = context;
        }
        public ICollection<Manager> Managers { get; set; }
        public ICollection<Band> Bands { get; set; }
        public ICollection<Concert> Concerts { get; set; }
        public ICollection<Song> Songs { get; set; }
        public void OnGet()
        {
            SearchCompleted = false;
            Managers = _context.Manager.OrderBy(x => x.ManagerName).ToList();
            Bands = _context.Band.OrderBy(x => x.BandName).Include(x => x.BandManager).ToList();
            Concerts = _context.Concert.OrderBy(x => x.ConcertName).Include(x => x.PerformingBand).ToList();
            Songs = _context.Song.OrderBy(x => x.Title).Include(x => x.Artist).ToList();
        }
        
        [BindProperty]
        public string BandUpdate { get; set; }
        [BindProperty]
        public string ManagerUpdate { get; set; }
        public bool SearchCompleted { get; set; }
        public void OnPost() {
            // PERFORM SEARCH
            if (string.IsNullOrWhiteSpace(BandUpdate)|| string.IsNullOrWhiteSpace(ManagerUpdate)) {
                return ;
            }
            else{
                
                Band BandRecord = _context.Band.Include(x => x.BandManager)
                                    .Where(x=> x.BandName == BandUpdate).Single();

                Manager ManagerRecord = _context.Manager.Where(x => x.ManagerName == ManagerUpdate).Single();


                BandRecord.BandManager = ManagerRecord;

                _context.SaveChanges();

                Bands = _context.Band.OrderBy(x => x.BandName).Include(x => x.BandManager).ToList();
                Managers = _context.Manager.OrderBy(x => x.ManagerName).ToList();

                SearchCompleted = true;

            }
        }
    }
}