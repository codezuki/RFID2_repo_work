using Microsoft.EntityFrameworkCore;
using RFID2.Model;

namespace RFID2.Pages.Utils
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Location> Locations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Location>()
                .HasIndex(l => l.LocationName)
                .IsUnique();

            modelBuilder.Entity<Location>()
                .Property(l => l.CreatedOn)
                .HasDefaultValueSql("getdate()");
        }
    }
}
