using Microsoft.EntityFrameworkCore;
using Weather.Models;

namespace Weather.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    public DbSet<Location> Locations { get; set; }
    public DbSet<Models.Forecast> Forecasts { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Forecast>()
            .HasOne(pr => pr.Location)
            .WithMany(p => p.Forecasts)
            .HasForeignKey(pr => pr.LocationID)
            .OnDelete(DeleteBehavior.Cascade);
            
        modelBuilder.Entity<Forecast>()
            .HasIndex(f => new { f.LocationID, f.Date })
            .IsUnique();

        modelBuilder.Entity<Location>()
            .HasIndex(loc => new{loc.Lat, loc.Lon} )
            .IsUnique();
    }
}