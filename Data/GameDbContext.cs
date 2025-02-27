using Microsoft.EntityFrameworkCore;
using API_56Cards.Models;

namespace API_56Cards.Data
{
    public class GameDbContext : DbContext
    {
        public GameDbContext(DbContextOptions<GameDbContext> options) : base(options)
        {
        }

        public DbSet<GameHistory> GameHistories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GameHistory>()
                .Property(g => g.GameDateTime)
                .HasDefaultValueSql("CURRENT_TIMESTAMP");
        }
    }
}
