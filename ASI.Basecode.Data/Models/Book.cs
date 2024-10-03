    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    namespace ASI.Basecode.Data.Models
    {
        public class Book
        {

            [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
       
            [Key]
            public int Id { get; set; }
            [Required]
            public string Title { get; set; }
            [Required]
            public string Description { get; set; }
            [Required]
            public string Author { get; set; }
            [Required]
            public DateTime DateTimeCreated   = DateTime.Now;
            public Book() { }
        }
    }
