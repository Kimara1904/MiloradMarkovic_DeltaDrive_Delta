using Exceptions.Exeptions;
using MiloradMarkovic_DeltaDrive_Delta.Helpers.Interfaces;
using MiloradMarkovic_DeltaDrive_Delta.Models;
using MiloradMarkovic_DeltaDrive_Delta.Repositories.Interfaces;
using MiloradMarkovic_DeltaDrive_Delta.Services.Interfaces;

namespace MiloradMarkovic_DeltaDrive_Delta.Services
{
    public class DriveSimulatorService : BackgroundService
    {
        private readonly IListService _listService;
        private readonly IGeoCalculator _geoCalculator;
        private readonly IServiceScopeFactory _scopeFactory;

        public DriveSimulatorService(IListService listService, IGeoCalculator geoCalculator, IServiceScopeFactory scopeFactory)
        {
            _listService = listService;
            _geoCalculator = geoCalculator;
            _scopeFactory = scopeFactory;

        }

        protected override async Task<Task> ExecuteAsync(CancellationToken stoppingToken)
        {
            stoppingToken.ThrowIfCancellationRequested();

            using var scope = _scopeFactory.CreateScope();
            var unitOfWork = scope.ServiceProvider.GetRequiredService<IUnitOfWork>();

            if (_listService.List.Any())
            {
                var task = _listService.List.Select(async item =>
                {
                    Location newLocation = null;
                    var vehicle = await unitOfWork._vehicleRepository.FindAsync(item.VehicleId)
                        ?? throw new InternalServerErrorException("Error with simulation: Vehicle doesn't exist.");

                    var ride = (await unitOfWork._rideRepository.GetAllAsync())
                        .Where(x => !x.IsArrived && IsSameLocation(x.StartingLocation, item.PassengersLocation)
                        && IsSameLocation(x.EndingLocation, item.Destination) && x.VehicleId == item.VehicleId).FirstOrDefault()
                        ?? throw new InternalServerErrorException("Error with simulation: Ride doesn't exist.");

                    if (item.IsPassengerPicked)
                    {
                        newLocation = await CalculateNewLocation(item.CurrentLocation, item.Destination);
                    }
                    else
                    {
                        newLocation = await CalculateNewLocation(item.CurrentLocation, item.PassengersLocation);
                    }

                    if (IsSameLocation(newLocation, item.PassengersLocation))
                    {
                        item.IsPassengerPicked = true;
                    }
                    else if (IsSameLocation(newLocation, item.Destination))
                    {
                        _listService.EmptyList(item);
                        vehicle.IsBooked = false;
                        ride.EndTime = DateTime.UtcNow;
                    }

                    vehicle.Location.Latitude = newLocation.Latitude;
                    vehicle.Location.Longitude = newLocation.Longitude;
                    unitOfWork._vehicleRepository.Update(vehicle);
                    unitOfWork._rideRepository.Update(ride);
                });

                await Task.WhenAll(task);

                await unitOfWork.Save();
            }

            return Task.CompletedTask;
        }

        private async Task<Location> CalculateNewLocation(Location current, Location destination)
        {
            var newLocation = new Location();

            await Task.Run(() =>
            {
                var distanceKM = _geoCalculator.CalculateDistance(current.Latitude, current.Longitude, destination.Latitude, destination.Longitude);
                var distanceTraveled = 60.0 * (5.0 / 3600.0); // distance = speed * (timeInSeconds / 3600 -> timeInHours)
                var ratio = distanceTraveled / distanceKM;

                newLocation.Latitude = ratio < 1
                    ? current.Latitude + ratio * (destination.Latitude - current.Latitude)
                    : destination.Latitude;

                newLocation.Longitude = ratio < 1
                    ? current.Longitude + ratio * (destination.Longitude - current.Longitude)
                    : destination.Longitude;
            });

            return newLocation;
        }

        private static bool IsSameLocation(Location location1, Location location2)
        {
            if (location1.Latitude == location2.Latitude && location1.Longitude == location2.Longitude)
            {
                return true;
            }
            return false;
        }
    }
}
