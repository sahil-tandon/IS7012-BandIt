
using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BandIt.Models
{
    public class Song
    {
        [Key]
        public int Id { get; set; }
                
        [Required(ErrorMessage = "Please provide a Song Title.")]
        public string Title { get; set; }

 //       [StringLength(5, MinimumLength=4, ErrorMessage = "Length should be of format mm:ss")]
        [RegularExpression("[0-9]{1,2}:[0-9][0-9]", ErrorMessage = "Length should be in mm:ss format")]
        [Display(Name = "Length")]
        [Required(ErrorMessage = "Please provide a Song Length.")]
        public string Duration { get; set; }  
        
        [Display(Name = "Rating (0-5)")]
        [Range(0,5, ErrorMessage = "Invalid Value")]
        public decimal Rating { get; set; }    

        [Display(Name = "Release Date")]
        [CustomValidation(typeof(Song), "CheckReleaseDate")]
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Please provide a Release Date.")]
        public DateTime? ReleaseDate { get; set; }

        public int BandID { get; set; }
        public Band Artist { get; set; }

        public static ValidationResult CheckReleaseDate(DateTime? ReleaseDate, ValidationContext context) {
            if (ReleaseDate == null) {
                return ValidationResult.Success;
            }
            if (ReleaseDate > DateTime.Today) {
                return new ValidationResult("Invalid Date");
            }
            return ValidationResult.Success;
        }
    }
}
            