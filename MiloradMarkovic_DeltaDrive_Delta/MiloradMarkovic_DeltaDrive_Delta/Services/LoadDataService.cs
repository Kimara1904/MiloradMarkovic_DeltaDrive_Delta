using CsvHelper;
using MiloradMarkovic_DeltaDrive_Delta.Models;
using MiloradMarkovic_DeltaDrive_Delta.Repositories.Interfaces;
using System.Globalization;

namespace MiloradMarkovic_DeltaDrive_Delta.Services
{
    public class LoadDataService : BackgroundService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IHostApplicationLifetime _applicationLifetime;

        public LoadDataService(IUnitOfWork unitOfWork, IHostApplicationLifetime applicationLifetime)
        {
            _unitOfWork = unitOfWork;
            _applicationLifetime = applicationLifetime;

        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _applicationLifetime.ApplicationStarted.Register(() =>
            {
                stoppingToken.ThrowIfCancellationRequested();

                var records = new List<Vehicle>();
                using var reader = new StreamReader("../../../../../delta-drive.csv");
                using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);

                while (csv.Read())
                {
                    var record = new Vehicle()
                    {
                        Brand = csv.GetField("brand") ?? throw new Exception("Can't find field 'brand'."),
                        DriversFirstName = csv.GetField("firstName") ?? throw new Exception("Can't find field 'firstName'."),
                        DriversLastName = csv.GetField("lastName") ?? throw new Exception("Can't find field 'lastName'."),
                        Location = new Location()
                        {
                            Latitude = double.Parse(csv.GetField("latitude") ?? throw new Exception("Can't find field 'latitude'.")),
                            Longitude = double.Parse(csv.GetField("longitude") ?? throw new Exception("Can't find field 'longitude'."))
                        },
                        StartPrice = double.Parse(csv.GetField("startPrice") ?? throw new Exception("Can't find field 'startPrice'.")),
                        PricePerKM = double.Parse(csv.GetField("pricePerKM") ?? throw new Exception("Can't find field 'pricePerKM'."))
                    };

                    records.Add(record);
                }

                _unitOfWork._vehicleRepository.AddRange(records);
                _unitOfWork.Save();
            });

            return Task.CompletedTask;
        }
    }
}
