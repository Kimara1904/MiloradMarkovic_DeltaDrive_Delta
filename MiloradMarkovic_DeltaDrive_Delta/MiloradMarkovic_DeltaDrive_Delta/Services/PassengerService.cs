using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MiloradMarkovic_DeltaDrive_Delta.DTOs;
using MiloradMarkovic_DeltaDrive_Delta.Repositories.Interfaces;
using MiloradMarkovic_DeltaDrive_Delta.Services.Interfaces;

namespace MiloradMarkovic_DeltaDrive_Delta.Services
{
    public class PassengerService : IPassengerService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public PassengerService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<HistoryPreviewDTO>> GetHistoryPreview(int id)
        {
            var historyQuery = await _unitOfWork._historyPreviewItemRepository.GetAllAsync();
            var history = historyQuery.Where(x => x.PassengerId == id).Include(x => x.Passenger).Include(x => x.Vehicle).OrderBy(x => x.DateTime).ToList();

            var returnVal = _mapper.Map<List<HistoryPreviewDTO>>(history);

            returnVal.ForEach(historyItem =>
            {
                historyItem.PassengerEmail.Equals(history[0].Passenger.Email);
            });

            return returnVal;
        }
    }
}
