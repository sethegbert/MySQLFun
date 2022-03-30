using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MySQLFun.Models
{
    // We need to set up our context that inherits from dbcontext, and create the bowlers set
    public class BowlersDbContext : DbContext
    {
        public BowlersDbContext()
        {
        }
        public BowlersDbContext(DbContextOptions<BowlersDbContext> options) : base (options)
        {

        }

        public DbSet<Bowler> Bowlers { get; set; }
    }
}
