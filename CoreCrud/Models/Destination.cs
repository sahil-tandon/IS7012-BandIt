
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
        public string Name { get; set; }
        public string Climate { get; set; }
        public string Food { get; set; }
        public decimal Cost { get; set; }
        public DateTime? PeakSeasonStart { get; set; }
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
        
        // ADD PROPERTIES HERE
    }
}
            