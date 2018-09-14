
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
        public DateTime PeakSeasonStart { get; set; }
        
        // ADD PROPERTIES HERE
    }
}
            