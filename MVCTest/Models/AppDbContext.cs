using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCTest.Models
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
          : base(options) {
        
     
        }
        

DbSet<Customer> Customers { get; set; }
        DbSet<Founder> Founders { get; set; }
    }
}
