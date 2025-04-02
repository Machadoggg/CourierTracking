using CourierTracking.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CourierTracking.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Courier> Couriers { get; set; }
        public DbSet<LocationHistory> LocationHistories { get; set; }
    }
}
