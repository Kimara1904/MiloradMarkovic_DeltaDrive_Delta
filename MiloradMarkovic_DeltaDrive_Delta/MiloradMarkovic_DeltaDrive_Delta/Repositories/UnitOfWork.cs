using Microsoft.EntityFrameworkCore;
using MiloradMarkovic_DeltaDrive_Delta.Models;
using MiloradMarkovic_DeltaDrive_Delta.Repositories.Interfaces;

namespace MiloradMarkovic_DeltaDrive_Delta.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DbContext _context;

        public IGenericRepository<Passenger> _passengerRepository { get; } = null!;
        public IGenericRepository<Vehicle> _vehicleRepository { get; } = null!;
        public IGenericRepository<Rate> _rateRepository { get; } = null!;
        public IGenericRepository<Ride> _rideRepository { get; } = null!;

        public UnitOfWork(DbContext context, IGenericRepository<Passenger> passengerRepository,
            IGenericRepository<Vehicle> vehicleRepository, IGenericRepository<Rate> rateRepository,
            IGenericRepository<Ride> rideRepository)
        {
            _context = context;
            _passengerRepository = passengerRepository;
            _vehicleRepository = vehicleRepository;
            _rateRepository = rateRepository;
            _rideRepository = rideRepository;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context.Dispose();
            }
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }
    }
}
