using AutoMapper;
using Exceptions.Exeptions;
using Microsoft.EntityFrameworkCore;
using MiloradMarkovic_DeltaDrive_Delta.DTOs;
using MiloradMarkovic_DeltaDrive_Delta.Helpers.Interfaces;
using MiloradMarkovic_DeltaDrive_Delta.Models;
using MiloradMarkovic_DeltaDrive_Delta.Repositories.Interfaces;
using MiloradMarkovic_DeltaDrive_Delta.Services.Interfaces;

namespace MiloradMarkovic_DeltaDrive_Delta.Services
{
    public class VehicleService : IVehicleService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IGeoCalculator _geoCalculator;
        private readonly IMapper _mapper;

        public VehicleService(IUnitOfWork unitOfWork, IGeoCalculator geoCalculator, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _geoCalculator = geoCalculator;
            _mapper = mapper;
        }

        public Task<bool> BookVehicle(BookVehicleDTO bookVehicle)
        {
            throw new NotImplementedException();
        }

        public async Task<List<AvailableVehicleDTO>> GetAvailableVehicles(AvailableVehicleLocationsDTO locations)
        {
            var vehiclesQuery = await _unitOfWork._vehicleRepository.GetAllAsync();
            var vehicles = vehiclesQuery.Where(x => !x.IsBooked).Include(x => x.Rates)
                .OrderBy(x => _geoCalculator.CalculateDistance(locations.PassengersLocation.Latitude, locations.PassengersLocation.Longitude, x.Location.Latitude, x.Location.Longitude))
                .Take(10).ToList();

            var availableVehicle = _mapper.Map<List<AvailableVehicleDTO>>(vehicles);

            var tasks = availableVehicle.Select(async vehicle =>
            {
                var tempVehicle = vehicles.FirstOrDefault(x => x.Id == vehicle.Id) ?? throw new NotFoundException("Error with finding vahicle.");
                //multiply by 1000 because we're looking for meters
                vehicle.DistanceToPassenger = 1000 * await _geoCalculator.CalculateDistance(locations.PassengersLocation.Latitude, locations.PassengersLocation.Longitude, tempVehicle.Location.Latitude, tempVehicle.Location.Longitude);
                vehicle.Rating = tempVehicle.Rates.Average(x => x.Rating);
                var distance = await _geoCalculator.CalculateDistance(locations.PassengersLocation.Latitude, locations.PassengersLocation.Longitude, locations.DistanceLocation.Latitude, locations.DistanceLocation.Longitude);
                vehicle.TotalPrice = vehicle.StartPrice + (vehicle.PricePerKM * distance);
            });

            await Task.WhenAll(tasks);

            return availableVehicle;
        }

        public async Task<List<RatesPreviewDTO>> GetRatesPreview(int id)
        {
            var previewsQuery = await _unitOfWork._rateRepository.GetAllAsync();
            var previews = previewsQuery.Where(x => x.Id == id).Include(x => x.Vehicle).Include(x => x.Passenger).ToList();

            return _mapper.Map<List<RatesPreviewDTO>>(previews);
        }

        public async Task<VehicleDetailDTO> GetVehicleById(int id)
        {
            var vehicle = await _unitOfWork._vehicleRepository.FindAsync(id);

            return _mapper.Map<VehicleDetailDTO>(vehicle);
        }

        public async Task RateVehicle(int passengerId, RateVehicleDTO rateVehicle)
        {
            var passenger = await _unitOfWork._passengerRepository.FindAsync(passengerId) ?? throw new NotFoundException("This passenger doesn't exists.");
            var vehicle = await _unitOfWork._vehicleRepository.FindAsync(rateVehicle.VehicleId) ?? throw new NotFoundException($"There is no vehicle with id: {rateVehicle.VehicleId}");

            var rate = _mapper.Map<Rate>(rateVehicle);
            rate.VehicleId = vehicle.Id;
            rate.PassengersId = passenger.Id;

            await _unitOfWork._rateRepository.Insert(rate);
            await _unitOfWork.Save();
        }
    }
}
