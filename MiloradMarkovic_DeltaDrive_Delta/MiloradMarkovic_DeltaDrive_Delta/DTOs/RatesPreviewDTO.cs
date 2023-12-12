namespace MiloradMarkovic_DeltaDrive_Delta.DTOs
{
    public class RatesPreviewDTO
    {
        public int Id { get; set; }
        public string PassengerEmail { get; set; } = null!;
        public VehicleDTO Vehicle { get; set; } = null!;
        public int Rating { get; set; }
        public string? Comment { get; set; }
    }
}
