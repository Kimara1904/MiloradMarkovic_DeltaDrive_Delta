using MiloradMarkovic_DeltaDrive_Delta.Models;

namespace MiloradMarkovic_DeltaDrive_Delta.Services.Interfaces
{
    public interface IListService
    {
        public List<VehicleLocation> List { get; }
        void FillList(VehicleLocation item);
        void EmptyList(VehicleLocation item);
    }
}
