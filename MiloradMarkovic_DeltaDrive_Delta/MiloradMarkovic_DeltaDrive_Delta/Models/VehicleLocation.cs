namespace MiloradMarkovic_DeltaDrive_Delta.Models
{
    public class VehicleLocation
    {
        public int VehicleId { get; set; }
        public Location PassengersLocation { get; set; } = null!;
        public Location Destination { get; set; } = null!;
        public bool IsPassengerPicked { get; set; }
    }
}
