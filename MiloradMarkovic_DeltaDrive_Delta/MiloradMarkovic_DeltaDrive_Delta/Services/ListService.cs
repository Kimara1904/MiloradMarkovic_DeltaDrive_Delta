using MiloradMarkovic_DeltaDrive_Delta.Models;
using MiloradMarkovic_DeltaDrive_Delta.Services.Interfaces;

namespace MiloradMarkovic_DeltaDrive_Delta.Services
{
    public class ListService : IListService
    {
        private readonly List<VehicleLocation> _vehicleLocations;

        public ListService()
        {
            _vehicleLocations = new List<VehicleLocation>();
        }

        public List<VehicleLocation> List => _vehicleLocations;

        public void EmptyList(VehicleLocation item)
        {
            _vehicleLocations.Remove(item);
        }

        public void FillList(VehicleLocation item)
        {
            _vehicleLocations.Add(item);
        }
    }
}
