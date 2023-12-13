using MiloradMarkovic_DeltaDrive_Delta.Models;

namespace MiloradMarkovic_DeltaDrive_Delta.DTOs
{
    public class BookVehicleDTO
    {
        public int Id { get; set; }
        public Location Start { get; set; } = null!;
        public Location Destination { get; set; } = null!;
    }
}
