
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
        public string BandName { get; set; }
        public string Members { get; set; }
        public string Genre { get; set; }
        public string Origin { get; set; }
        public string Website { get; set; }
        public string Logo { get; set; }

        [Display(Name = "Date Founded")]
        [DataType(DataType.Date)]
        public DateTime? DateFounded{ get; set; }
        public ICollection<Song> Songs { get; set; }
        public ICollection<Concert> Concerts { get; set; }
        public Manager BandManager { get; set; }

        // ADD PROPERTIES HERE
    }
}
            