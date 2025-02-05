using Microsoft.EntityFrameworkCore;
using Backend.Models;
using Microsoft.Extensions.Configuration;

namespace Backend
{
    public class WardrobeDBContext: DbContext
    {
        private readonly IConfiguration Configuration;
        public WardrobeDBContext(DbContextOptions<WardrobeDBContext> options) : base(options)
        {
        }
        public DbSet<ClothingItem> ClothingItems { get; set; }
        public DbSet<UserLogin> UserLogins { get; set; }
        public DbSet<UserProfile> Profiles { get; set; }
        public DbSet<WearingHistory> WearingHistories { get; set; }
        public DbSet<Outfit> Outfits { get; set; }

        public DbSet<ImageLocation> ImageLocations { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var connectionString = Configuration.GetConnectionString("WardrobeApp");
                optionsBuilder.UseSqlServer(connectionString);
            }
        }

    }
}
