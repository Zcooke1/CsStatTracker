using CsStatTracker.Models;
using Microsoft.EntityFrameworkCore;

namespace CsStatTracker.Data
{
    public class StatsContext : DbContext
    {
        public StatsContext(DbContextOptions<StatsContext> options)
            : base(options)
        {

        }
        public DbSet<Members> Members { get; set; }
        public DbSet<Segments> MemberStats { get; set; }
    }
}
