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
    public class SongListingModel : PageModel
    {
        public AppDbContext _context;
        public SongListingModel(AppDbContext context){
            _context = context;
        }

        public  ICollection<Song> Songs { get; set; }

        public IActionResult OnGet(int? id)
        {
            SearchCompleted = false;
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
        [BindProperty]
        [CustomValidation(typeof(SongListingModel), "CheckSortValue")]
        public string SortValue { get; set; }
        public bool SearchCompleted { get; set; }
        public ICollection<Song> SortResults { get; set; }
        
        public void OnPost(int? id) {
            // PERFORM SEARCH
            if(SortValue == "Default" || SortValue == "Title"){
                if(id != null){
                    SortResults =  _context.Song.OrderBy(x => x.Title).Where(x => x.Artist.Id == id).Include(x => x.Artist).ToList();
                    SearchCompleted = true;
                }
                else{
                    SortResults =  _context.Song.OrderBy(x => x.Title).Include(x => x.Artist).ToList();
                    SearchCompleted = true;
                }
            }
            if(SortValue == "Rating"){
                if(id != null){
                    SortResults =  _context.Song.OrderBy(x => x.Rating).Where(x => x.Artist.Id == id).Include(x => x.Artist).ToList();
                    SearchCompleted = true;
                }
                else{
                    SortResults =  _context.Song.OrderBy(x => x.Rating).Include(x => x.Artist).ToList();
                    SearchCompleted = true;
                }
            }
            if(SortValue == "Duration"){
                if(id != null){
                    SortResults =  _context.Song.OrderBy(x => x.Duration).Where(x => x.Artist.Id == id).Include(x => x.Artist).ToList();
                    SearchCompleted = true;
                }
                else{
                    SortResults =  _context.Song.OrderBy(x => x.Duration).Include(x => x.Artist).ToList();
                    SearchCompleted = true;
                }
            }
            if(SortValue == "Release Date"){
                if(id != null){
                    SortResults =  _context.Song.OrderBy(x => x.ReleaseDate).Where(x => x.Artist.Id == id).Include(x => x.Artist).ToList();
                    SearchCompleted = true;
                }
                else{
                    SortResults =  _context.Song.OrderBy(x => x.ReleaseDate).Include(x => x.Artist).ToList();
                    SearchCompleted = true;
                }
            }
            if(SortValue == "Artist"){
                if(id != null){
                    SortResults =  _context.Song.OrderBy(x => x.Artist.BandName).Where(x => x.Artist.Id == id).Include(x => x.Artist).ToList();
                    SearchCompleted = true;
                }
                else{
                    SortResults =  _context.Song.OrderBy(x => x.Artist.BandName).Include(x => x.Artist).ToList();
                    SearchCompleted = true;
                }
            }    
        }
        public static ValidationResult CheckSortValue(string SortValue, ValidationContext context) {
            if (SortValue == "Default" || SortValue == "Title" || SortValue == "Duration" || SortValue == "Rating" || SortValue == "Release Date" || SortValue == "Artist") {
                return ValidationResult.Success;
            }
            else
                return new ValidationResult("Invalid Input");
        }
    }
}