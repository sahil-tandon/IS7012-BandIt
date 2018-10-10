
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
        public string ConcertName { get; set; }
        public string Venue { get; set; }
        public DateTime Date { get; set; }
        public string TicketPrice { get; set; }
        public Band PerformingBand { get; set; }
    }
}
            