using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASI.Basecode.Data.Models
{
    public class Customer
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        [Key]
        public int customerId { get; set; }
        [Required]
        public string customerName { get; set; }
        [Required]
        public string customerEmail { get; set; }
        [Required]
        public string role { get; set; }
        [Required]
        public string customerPassword { get; set; }
        [Required]
        public DateTime DateTimeCreated = DateTime.Now;
    }
}
