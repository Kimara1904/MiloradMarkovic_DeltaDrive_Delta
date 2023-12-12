using CsvHelper.Configuration.Attributes;

namespace MiloradMarkovic_DeltaDrive_Delta.Models
{
    public class CSVVehicle
    {
        [Name("brand")]
        public string Brand { get; set; } = null!;
        [Name("firstName")]
        public string FirstName { get; set; } = null!;
        [Name("lastName")]
        public string LastName { get; set; } = null!;
        [Name("latitude")]
        public double Latitude { get; set; }
        [Name("longitude")]
        public double Longitude { get; set; }
        [Name("startPrice")]
        public string StartPrice { get; set; } = null!;
        [Name("pricePerKM")]
        public string PricePerKM { get; set; } = null!;
    }
}
