
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
        [Display(Name = "Length (in seconds)")]
        [Required(ErrorMessage = "Please provide a Song Length.")]
        public string Duration { get; set; }     //Add regex
        [Display(Name = "Rating (0-5)")]
        public decimal Rating { get; set; }     //Restrict rating to decimal between 0 to 5
        [Display(Name = "Release Date")]
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Please provide a Release Date.")]
        public DateTime? ReleaseDate { get; set; }
        public int BandID { get; set; }
        public Band Artist { get; set; }
    }
}
            