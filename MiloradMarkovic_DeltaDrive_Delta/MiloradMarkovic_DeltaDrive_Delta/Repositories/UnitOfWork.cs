using Microsoft.EntityFrameworkCore;
using MiloradMarkovic_DeltaDrive_Delta.Interfaces;
using MiloradMarkovic_DeltaDrive_Delta.Models;

namespace MiloradMarkovic_DeltaDrive_Delta.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DbContext _context;

        public IGenericRepository<Passenger> _passengerRepository { get; } = null!;
        public IGenericRepository<Vehicle> _vehicleRepository { get; } = null!;
        public IGenericRepository<Rate> _rateRepository { get; } = null!;
        public IGenericRepository<HistoryPreviewItem> _historyPreviewItemRepository { get; } = null!;

        public UnitOfWork(DbContext context)
        {
            _context = context;
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
