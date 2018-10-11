
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
        
        [Display(Name = "Title")]
        [Required(ErrorMessage = "Please provide a Song Title.")]
        public string Name { get; set; }
        [Display(Name = "Length (in seconds)")]
        [Required(ErrorMessage = "Please provide a Song Length.")]
        public int Length { get; set; }     //Restrict input to seconds only
        [Display(Name = "Rating (0-5)")]
        public decimal Rating { get; set; }     //Restrict rating to decimal between 0 to 5
        [Display(Name = "Release Date")]
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Please provide a Release Date.")]
        public DateTime? ReleaseDate { get; set; }
        public Band Artist { get; set; }
    }
}
            