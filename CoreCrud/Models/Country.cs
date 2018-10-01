
using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace CoreCrud.Models
{
    public class Country
    {
        [Key]
        public int Id { get; set; }
        
        [Required(ErrorMessage = "Please provide a name")]
        [StringLength(80, MinimumLength=4, ErrorMessage = "4 - 80 characters only")]
        
        [CustomValidation(typeof(Country), "checkForDigits")]
        public string Name { get; set; }
        public ICollection<Destination> Destination { get; set; }

        public string FetchCountry  {
            get{
                if(Id == 1){
                    return "India";
                }
                if(Id == 2){
                    return "United States";
                }
                if(Id == 3){
                    return "Netherlands";
                }
                if(Id == 4){
                    return "England";
                }
                if(Id == 5){
                    return "France";
                }
                if(Id == 6){
                    return "Italy";
                }
                return Name;
            }
        }

        //Custom validator to block country name's that contain digits
        public static ValidationResult checkForDigits(string countryName, ValidationContext context) {
            if (countryName != null) {            
                Regex rgx = new Regex(@"^[a-zA-Z]+$");                
                if(rgx.IsMatch(countryName)){            
                    return ValidationResult.Success;
                }
            }
            return new ValidationResult("Name can't contain digits");            
        }
    }
}
            