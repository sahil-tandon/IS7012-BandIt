using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BandIt.Models;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

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
        [CustomValidation(typeof(AdminModel), "CheckBandUpdateValue")]
        public string BandUpdate { get; set; }

        [BindProperty]
        [CustomValidation(typeof(AdminModel), "CheckManagerUpdateValue")]
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
        public static ValidationResult CheckBandUpdateValue(string BandUpdate, ValidationContext context) {
            bool presence = false;
            var dbContext = context.GetService(typeof(AppDbContext)) as AppDbContext;
            ICollection<Band> Bands = dbContext.Band.OrderBy(x => x.BandName).Include(x => x.BandManager).ToList();
            foreach(var code in Bands){
                if (@code.BandName.Contains(BandUpdate)) {
                 presence = true;
                }
                else
                    presence = false;
            }
            if(presence == false)
                return new ValidationResult("Invalid Input");
            else
                return ValidationResult.Success;
        }
        public static ValidationResult CheckManagerUpdateValue(string ManagerUpdate, ValidationContext context) {
            bool presence = false;
            var dbContext = context.GetService(typeof(AppDbContext)) as AppDbContext;
            ICollection<Manager> Managers = dbContext.Manager.OrderBy(x => x.ManagerName).ToList();
            foreach(var code in Managers){
                if (@code.ManagerName.Contains(ManagerUpdate)) {
                 presence = true;
                }
                else
                    presence = false;
            }
            if(presence == false)
                return new ValidationResult("Invalid Input");
            else
                return ValidationResult.Success;
        }
    }
}