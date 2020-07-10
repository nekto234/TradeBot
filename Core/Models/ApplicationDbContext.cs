using Microsoft.EntityFrameworkCore;

namespace Core.Models
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<MarketItem> MarketItems { get; set; }
        public DbSet<SteamItem> SteamItems { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder dbContextOptionsBuilder)
        {
            dbContextOptionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=CoreBotDB;Trusted_Connection=True;");
        }
    }
}
