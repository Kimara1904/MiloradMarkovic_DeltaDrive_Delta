using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MiloradMarkovic_DeltaDrive_Delta.Models;

namespace MiloradMarkovic_DeltaDrive_Delta.Infrastructure.Configurations
{
    public class VehicleConfiguration : IEntityTypeConfiguration<Vehicle>
    {
        public void Configure(EntityTypeBuilder<Vehicle> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Brand).IsRequired();
            builder.Property(x => x.DriversFirstName).IsRequired();
            builder.Property(x => x.DriversLastName).IsRequired();
            builder.OwnsOne(x => x.Location, sa =>
            {
                sa.Property(l => l.Latitude).IsRequired();
                sa.Property(l => l.Longitude).IsRequired();
            });
            builder.Property(x => x.StartPrice).IsRequired();
            builder.Property(x => x.PricePerKM).IsRequired();
        }
    }
}
