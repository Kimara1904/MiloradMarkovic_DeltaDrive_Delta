using Microsoft.EntityFrameworkCore;
using MiloradMarkovic_DeltaDrive_Delta.Models;

namespace MiloradMarkovic_DeltaDrive_Delta.Infrastructure
{
    public class DriveDatabaseContext : DbContext
    {
        public DbSet<Passenger> Passengers { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<Rate> Rates { get; set; }
        public DbSet<HistoryPreviewItem> History { get; set; }

        public DriveDatabaseContext(DbContextOptions<DriveDatabaseContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseLazyLoadingProxies();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(DriveDatabaseContext).Assembly);
        }
    }
}
