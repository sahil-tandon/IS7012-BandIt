
using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CoreCrud.Models
{
    public class Country
    {
        [Key]
        public int Id { get; set; }
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
        //public object Position { get; internal set; }

        // ADD PROPERTIES HERE
    }
}
            