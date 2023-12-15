namespace MiloradMarkovic_DeltaDrive_Delta.DTOs
{
    public class AvailableVehicleDTO
    {
        public int Id { get; set; }
        public string Brand { get; set; } = null!;
        public string DriversFirstName { get; set; } = null!;
        public string DriversLastName { get; set; } = null!;
        public double DistanceToPassenger { get; set; }
        public double Rating { get; set; }
        public double StartPrice { get; set; }
        public double PricePerKM { get; set; }
        public double TotalPrice { get; set; }
    }
}
