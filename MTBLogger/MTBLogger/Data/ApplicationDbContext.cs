using Microsoft.EntityFrameworkCore;
using MTBLogger.Models;
using System.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MTBLogger.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }

        public DbSet<User> User { get; set; }
        public DbSet<Logged> Logged { get; set; }
        public DbSet<ToRide> ToRide { get; set; }
    }
}
