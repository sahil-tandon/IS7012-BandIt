
using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BandIt.Models
{
    public class Band
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Name cannot be blank")]
        [Display(Name = "Band Name")]
        public string BandName { get; set; }

        [Required(ErrorMessage = "Members field cannot be blank")]
        [Display(Name = "Band Members")]
        public string Members { get; set; }

        [Required(ErrorMessage = "Genre cannot be blank")]
        public string Genre { get; set; }
        public string Origin { get; set; }
        public string Website { get; set; }
        
        [Display(Name = "Image Path")]
        public string Image { get; set; }

        [CustomValidation(typeof(Band), "CheckDateFounded")]
        [Display(Name = "Date Founded")]
        public int DateFounded { get; set; }
        public ICollection<Song> Songs { get; set; }
        public ICollection<Concert> Concerts { get; set; }

        [Display(Name = "Band Manager")]
        public int ManagerID { get; set; }
        public Manager BandManager { get; set; }

        public static ValidationResult CheckDateFounded(int? DateFounded, ValidationContext context) {
            if (DateFounded == null) {
                return ValidationResult.Success;
            }
            if (DateFounded < 1500 || DateFounded > DateTime.Now.Year) {
                return new ValidationResult("Invalid Date");
            }
            return ValidationResult.Success;
        }
    }
}
            