using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MiloradMarkovic_DeltaDrive_Delta.Models;

namespace MiloradMarkovic_DeltaDrive_Delta.Infrastructure.Configurations
{
    public class RateConfiguration : IEntityTypeConfiguration<Rate>
    {
        public void Configure(EntityTypeBuilder<Rate> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Rating).HasDefaultValue(1).IsRequired();
            builder.HasOne(x => x.Passenger).WithMany(p => p.Rates).HasForeignKey(x => x.PassengersId);
            builder.HasOne(x => x.Vehicle).WithMany(v => v.Rates).HasForeignKey(x => x.VehicleId);
        }
    }
}
