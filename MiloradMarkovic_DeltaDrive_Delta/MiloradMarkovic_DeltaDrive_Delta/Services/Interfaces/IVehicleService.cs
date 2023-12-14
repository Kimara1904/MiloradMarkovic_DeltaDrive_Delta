using MiloradMarkovic_DeltaDrive_Delta.DTOs;

namespace MiloradMarkovic_DeltaDrive_Delta.Services.Interfaces
{
    public interface IVehicleService
    {
        Task<List<AvailableVehicleDTO>> GetAvailableVehicles(AvailableVehicleLocationsDTO locations);
        Task<bool> BookVehicle(int PassengerId, BookVehicleDTO bookVehicle);
        Task<List<RatesPreviewDTO>> GetRatesPreview(int id);
        Task RateVehicle(int PassengerId, RateVehicleDTO rateVehicle);
        Task<VehicleDetailDTO> GetVehicleById(int id);
    }
}
