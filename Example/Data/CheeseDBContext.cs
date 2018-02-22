using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Example.Models;

namespace Example.Data
{
    public class CheeseDBContext : DbContext
    {
        public DbSet<Cheese> Cheeses { get; set; }
        public DbSet<CheeseCategory> Categories { get; set; }

        public CheeseDBContext(DbContextOptions<CheeseDBContext> options) : base(options)
        {

        }
    }
}
