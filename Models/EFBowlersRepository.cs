using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MySQLFun.Models
{
    // this is going to implement the interface repository. it acts as the middle man
    public class EFBowlersRepository : IBowlersRepository
    {
        // build private variable as instance of the context
        private BowlersDbContext context { get; set; }

        // then we implement the functionality that we were doing in homecontroller, but now here

        public EFBowlersRepository (BowlersDbContext temp)
        {
            context = temp;
        }
        public IQueryable<Bowler> Bowlers => context.Bowlers;

        public void SaveBowler(Bowler b)
        {
            context.SaveChanges();
        }

        public void CreateBowler(Bowler b)
        {
            context.Add(b);
            context.SaveChanges();
        }

        public void DeleteBowler(Bowler b)
        {
            context.Remove(b);
            context.SaveChanges();
        }
    }
}
