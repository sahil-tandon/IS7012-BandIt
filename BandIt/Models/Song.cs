
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
        public string Name { get; set; }
        public int Length { get; set; }     //Restrict input to seconds only
        public decimal Rating { get; set; }     //Restrict rating to decimal between 0 to 5
        public DateTime? ReleaseDate { get; set; }
        public Band Artist { get; set; }
    }
}
            