
using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BandIt.Models
{
    public class Manager
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Name cannot be blank")]
        [Display(Name = "Manager Name")]
        public string ManagerName { get; set; }

        [Range(0, 110, ErrorMessage = "Enter a valid number")]
        public int Age { get; set; }


        [Phone]    
        [StringLength(10, MinimumLength=10, ErrorMessage = "Phone number should be only 10 digits")]
        public string Phone { get; set; }  
                
        [EmailAddress]
        [Required(ErrorMessage = "Email is required")]  
        public string Email { get; set; }

        public string Image { get; set; }

        [CustomValidation(typeof(Manager), "CheckExperience")]
        public int Experience { get; set;}
        public string Nationality { get; set; }
        public ICollection<Band> Bands { get; set; }
                
        
        public static ValidationResult CheckExperience(int? Experience, ValidationContext context) {
            if (Experience == null) {
                return ValidationResult.Success;
            }
            var instance = context.ObjectInstance as Manager;
            if (instance == null) {
                return ValidationResult.Success;
            }
            if (Experience > instance.Age) {
                return new ValidationResult("Experience cannot be greater than age");
            }
            return ValidationResult.Success;
        }
    }
}
            