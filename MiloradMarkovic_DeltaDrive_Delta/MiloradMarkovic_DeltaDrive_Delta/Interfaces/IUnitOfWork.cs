using MiloradMarkovic_DeltaDrive_Delta.Models;

namespace MiloradMarkovic_DeltaDrive_Delta.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        public IGenericRepository<Passenger> _passengerRepository { get; }
        public IGenericRepository<Vehicle> _vehicleRepository { get; }
        public IGenericRepository<Rate> _rateRepository { get; }
        public IGenericRepository<HistoryPreviewItem> _historyPreviewItemRepository { get; }
        Task Save();
    }
}
