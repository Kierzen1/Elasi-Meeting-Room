using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ASI.Basecode.Data.Models
{
    public partial class User
    {
        
        public int Id { get; set; }
        public string UserId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
        public string Password { get; set; }
        public string CreatedBy { get; set; }

        public DateTime CreatedTime = DateTime.Now;
        public string UpdatedBy { get; set; }
        public DateTime UpdatedTime { get; set; } = DateTime.Now;

    }
}
