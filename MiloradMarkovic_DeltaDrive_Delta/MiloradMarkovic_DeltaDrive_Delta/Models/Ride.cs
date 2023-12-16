namespace MiloradMarkovic_DeltaDrive_Delta.Models
{
    public class Ride
    {
        public int Id { get; set; }
        public Location StartingLocation { get; set; } = null!;
        public Location EndingLocation { get; set; } = null!;
        public double TotalPrice { get; set; }
        public int PassengerId { get; set; }
        public virtual Passenger Passenger { get; set; } = null!;
        public int VehicleId { get; set; }
        public virtual Vehicle Vehicle { get; set; } = null!;
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public bool IsArrived { get; set; }
        public bool IsRated { get; set; }
    }
}
