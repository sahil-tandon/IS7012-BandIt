
using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CoreCrud.Models
{
    public class Destination
    {
        [Key]
        public int Id { get; set; }
        
        [Required(ErrorMessage = "Please provide a name")]
        [StringLength(100, MinimumLength=2, ErrorMessage = "2 - 100 characters only")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please describe the climate")]
        [StringLength(50)]
        public string Climate { get; set; }
        
        [StringLength(100)]
        public string Food { get; set; }
        
        [Required(ErrorMessage = "Please provide a cost estimate")]
        [Range(1, 5000 , ErrorMessage = "Cost must be a valid number")]
        public decimal Cost { get; set; }

        [Display(Name = "Peak Season Start Date")]
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Please indicate a peak season start date")]
        [CustomValidation(typeof(Destination), "SeasonYearInThePast")]
        public DateTime? PeakSeasonStart { get; set; }
        
        [Display(Name = "Country ID")]
        public int CountryID { get; set; }
        public Country Country { get; set; }

        public string Affordability {
            get {
                if(Cost <= 300){
                    return "Cheap";
                }
                if(Cost >300 & Cost <= 600){
                    return "Reasonable";
                }
                if(Cost > 600){
                    return "Expensive";
                }
                return Cost.ToString();
            }
        }

        //Custom validator to block season start date's with year in the past
        public static ValidationResult SeasonYearInThePast(DateTime? seasonStartDate, ValidationContext context) {                        
            if (seasonStartDate != null) {
                if (seasonStartDate.Value.Year >= 2018) {
                    return ValidationResult.Success;
                }
            }            
            return new ValidationResult("Season Start Year can not be in the Past");
        }
    }
}
            