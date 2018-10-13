
using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BandIt.Models
{
    public class Concert
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Concert Name")]
        [Required(ErrorMessage = "Please provide a Concert Name.")]
        public string ConcertName { get; set; }

        [Required(ErrorMessage = "Please provide a Concert Venue.")]
        public string Venue { get; set; }

        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Please provide a Concert Date.")]
        public DateTime? Date { get; set; }

        [Display(Name = "Ticket Price (USD)")]
        [Required(ErrorMessage = "Please provide a Ticket Price.")]
        public decimal TicketPrice { get; set; }

        [Display(Name = "Performing Band")]
        [Required(ErrorMessage = "Please select a Performing Band.")]
        public int BandID { get; set; }
        public Band PerformingBand { get; set; }

    }
}
            