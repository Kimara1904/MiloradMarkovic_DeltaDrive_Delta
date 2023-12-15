using MiloradMarkovic_DeltaDrive_Delta.Models;

namespace MiloradMarkovic_DeltaDrive_Delta.Repositories.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        public IGenericRepository<Passenger> _passengerRepository { get; }
        public IGenericRepository<Vehicle> _vehicleRepository { get; }
        public IGenericRepository<Rate> _rateRepository { get; }
        public IGenericRepository<Ride> _rideRepository { get; }
        Task Save();
    }
}
