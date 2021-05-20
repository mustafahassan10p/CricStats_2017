using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CricStats.Models
{
    public class Cricketer
    {
        public int ID { get; set; }
        public string Name {get; set;}
        public decimal TestAvg {get; set;}
        public decimal ODIAvg {get; set;}
        public decimal T20Avg {get; set;}
        public string Grade { get; set; }
    }

    public class CricketerDBContext : DbContext
    {
        public DbSet<Cricketer> Cricketers { get; set; }
    }
}