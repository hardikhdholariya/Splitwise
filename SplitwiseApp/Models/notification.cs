using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SplitwiseApp.Models
{
    public class notification
    {
        public int ID { get; set; }
        public string loginuser { get; set; }
        public string friendemail { get; set; }
        public string description { get; set; }
        public decimal amount { get; set; }
    }

    public class notificationDBContext : DbContext
    {
        public DbSet<notification> notifications { get; set; }
    }
}