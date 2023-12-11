namespace MiloradMarkovic_DeltaDrive_Delta.Models
{
    public class Rate
    {
        public int Id { get; set; }
        public int PassengersId { get; set; }
        public virtual Passenger Passenger { get; set; } = null!;
        public int VehicleId { get; set; }
        public virtual Vehicle Vehicle { get; set; } = null!;
        public int Rating { get; set; }
        public string? Comment { get; set; }
    }
}
