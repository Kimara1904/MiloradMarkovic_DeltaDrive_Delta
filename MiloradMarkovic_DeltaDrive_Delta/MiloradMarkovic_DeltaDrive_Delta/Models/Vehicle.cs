namespace MiloradMarkovic_DeltaDrive_Delta.Models
{
    public class Vehicle
    {
        public int Id { get; set; }
        public string Brand { get; set; } = null!;
        public string DriversFirstName { get; set; } = null!;
        public string DriversLastName { get; set; } = null!;
        public Location Location { get; set; } = null!;
        public double StartPrice { get; set; }
        public double PricePerKM { get; set; }
        public bool IsBooked { get; set; }
        public virtual List<Rate> Rates { get; set; } = null!;
        public virtual List<Ride> HistoryPreviews { get; set; } = null!;
    }
}
