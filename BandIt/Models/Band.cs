
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

        [Display(Name = "Date Founded")]
        [DataType(DataType.Date)]
        public int DateFounded { get; set; }
        public ICollection<Song> Songs { get; set; }
        public ICollection<Concert> Concerts { get; set; }
        public int ManagerID { get; set; }
        public Manager BandManager { get; set; }
    }
}
            