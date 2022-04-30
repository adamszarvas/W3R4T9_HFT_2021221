using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace W3R4T9_HFT_2021221.Models
{
    [Table("flight")]
    public class Flight
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        
        
        [MaxLength(20)]
        public string Destination { get; set; }

     
        [MaxLength(20)]
        public string From { get; set; }

        public int? Seats { get; set; }

        
        public int? TicketPrice { get; set; }

        
       
        [JsonIgnore]
        [NotMapped]
        public virtual Airline Airline { get; set; }
        
        [NotMapped]
        public virtual ICollection<Passenger> Passengers { get; set; }

        public Flight()
        {
            Passengers = new HashSet<Passenger>();
        }

    }
}
