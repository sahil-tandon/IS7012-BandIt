using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreCrud.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace CoreCrud.Pages
{
    public class IndexModel : PageModel
    {
        public decimal TotalDestinations {get; set;}
        public decimal AverageCost {get; set;}
        private AppDbContext _context;
        public IndexModel(AppDbContext context) {
            _context = context;
        }
        public void OnGet()
        {
            TotalDestinations = _context.Destination.Where(x=>x.Id > 0).Count();
            AverageCost = _context.Destination.Average(x=>x.Cost);
            AverageCost = Math.Round(AverageCost,2);
        }
    }
}
