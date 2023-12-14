using MiloradMarkovic_DeltaDrive_Delta.Models;

namespace MiloradMarkovic_DeltaDrive_Delta.DTOs
{
    public class HistoryPreviewDTO
    {
        public int Id { get; set; }
        public Location StartingLocation { get; set; } = null!;
        public Location EndingLocation { get; set; } = null!;
        public double TotalPrice { get; set; }
        public string PassengerEmail { get; set; } = null!;
        public VehicleDTO Vehicle { get; set; } = null!;
        public DateTime DateTime { get; set; }
    }
}
