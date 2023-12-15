using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MiloradMarkovic_DeltaDrive_Delta.Models;

namespace MiloradMarkovic_DeltaDrive_Delta.Infrastructure.Configurations
{
    public class HistoryPreviewItemConfiguration : IEntityTypeConfiguration<HistoryPreviewItem>
    {
        public void Configure(EntityTypeBuilder<HistoryPreviewItem> builder)
        {
            builder.HasKey(x => x.Id);
            builder.OwnsOne(x => x.StartingLocation, sa =>
            {
                sa.Property(l => l.Latitude).IsRequired().HasColumnName("StartLatitude");
                sa.Property(l => l.Longitude).IsRequired().HasColumnName("StartLongitude");
            });
            builder.OwnsOne(x => x.EndingLocation, sa =>
            {
                sa.Property(l => l.Latitude).IsRequired().HasColumnName("EndLatitude");
                sa.Property(l => l.Longitude).IsRequired().HasColumnName("EndLongitude");
            });
            builder.Property(x => x.TotalPrice).IsRequired();
            builder.Property(x => x.StartTime).IsRequired();
            builder.Property(x => x.IsArrived).HasDefaultValue(false);
            builder.HasOne(x => x.Passenger).WithMany(p => p.HistoryPreviews).HasForeignKey(x => x.PassengerId);
            builder.HasOne(x => x.Vehicle).WithMany(v => v.HistoryPreviews).HasForeignKey(x => x.VehicleId);
        }
    }
}
