using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using BandIt.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace BandIt.Pages
{
    public class ManagerListingModel : PageModel
    {
        private AppDbContext _context;
        
        public ManagerListingModel(AppDbContext context) {
            _context = context;
        }

        public ICollection<Manager> Managers { get; set; }
        public void OnGet()
        {
            SearchCompleted = false;
            
            Managers = _context.Manager.OrderBy(x => x.ManagerName).ToList();
        }
        [BindProperty]
        [StringLength(30, ErrorMessage = "Invalid Input")]
        public string Search { get; set; }
        public bool SearchCompleted { get; set; }
        public ICollection<Manager> SearchResults { get; set; }
        
        public void OnPost() {
            // PERFORM SEARCH
            if (string.IsNullOrWhiteSpace(Search)) {
                SearchResults =  _context.Manager.OrderBy(x => x.ManagerName).ToList();
                SearchCompleted = true;
            }
            else{
                SearchResults = _context.Manager
                                    .Where(x => x.ManagerName.ToLower().Contains(Search.ToLower()))
                                    .ToList();
                SearchCompleted = true;
            }
        }
    }
}