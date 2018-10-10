
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
        public string ManagerName { get; set; }
        public int Age { get; set; }
        public int Experience { get; set;}
        public string Nationality { get; set; }
        public ICollection<Band> Bands { get; set; }
                
    }
}
            