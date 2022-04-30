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
    [Table("Passenger")]
    public class Passenger
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        
        [MaxLength(20)]
        public string Name { get; set; }
       
        public int? Age { get; set; }

        [JsonIgnore]
        [NotMapped]
        public virtual Flight Flight { get; set; }

         
    }
}
