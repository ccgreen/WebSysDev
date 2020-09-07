using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebSysDev.Models
{
    public class Room
    {
        public int ID { get; set; }

        [Required]
        [RegularExpression(@"[1-3G]")]
        public string Level { get; set; }
        [Range(1, 3)]
        public int BedCount { get; set; }
        [Range(50, 300)]
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }
        public ICollection<Booking> TheBookings {get; set;}
    }
}
