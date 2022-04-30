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
    [Table("airline")]
    public class Airline
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [MaxLength(20)]
        public string Name { get; set; }
        public string Region { get; set; }
        public int? PassengersYearly { get; set; }

        
        [NotMapped]
        public virtual ICollection<Flight> Flights { get; set; }

        public Airline()
        {
            Flights = new HashSet<Flight>();
        }

    }
}
