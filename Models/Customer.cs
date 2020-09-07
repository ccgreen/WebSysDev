using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebSysDev.Models
{
    public class Customer
    {
        [Key, Required]
        [DataType(DataType.EmailAddress)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string Email { get; set; }
        [Required]
        [RegularExpression(@"[A-Z][a-z'-]{2,20}")]
        public string Surname { get; set; }
        [Required]
        [Display(Name = "First Name")]
        [RegularExpression(@"[A-Z][a-z'-]{2,20}")]
        public string GivenName { get; set; }
        public string Postcode { get; set; }
        public ICollection<Booking> TheBookings { get; set; }
    }
}
