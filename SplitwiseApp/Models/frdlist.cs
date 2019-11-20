using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SplitwiseApp.Models
{
    public class frdlist
    {
        public int ID { get; set; }
        public string loginuser { get; set; }
        [Required]
        public string friendname { get; set; }
        [Required]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }
        public decimal rupee { get; set; }
    }

    public class frdlistDBContext : DbContext
    {
        public DbSet<frdlist> frdlists { get; set; }
    }
}