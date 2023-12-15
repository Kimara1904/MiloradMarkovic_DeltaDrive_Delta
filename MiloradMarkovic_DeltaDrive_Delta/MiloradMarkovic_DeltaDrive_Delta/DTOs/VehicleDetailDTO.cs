using MiloradMarkovic_DeltaDrive_Delta.Models;

namespace MiloradMarkovic_DeltaDrive_Delta.DTOs
{
    public class VehicleDetailDTO
    {
        public int Id { get; set; }
        public string Brand { get; set; } = null!;
        public string DriversFirstName { get; set; } = null!;
        public string DriversLastName { get; set; } = null!;
        public bool IsBooked { get; set; }
        public Location Location { get; set; } = null!;
    }
}
