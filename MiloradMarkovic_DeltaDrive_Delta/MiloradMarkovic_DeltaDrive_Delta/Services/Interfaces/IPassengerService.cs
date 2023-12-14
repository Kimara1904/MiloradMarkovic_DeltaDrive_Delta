using MiloradMarkovic_DeltaDrive_Delta.DTOs;

namespace MiloradMarkovic_DeltaDrive_Delta.Services.Interfaces
{
    public interface IPassengerService
    {
        Task<List<HistoryPreviewDTO>> GetHistoryPreview(int id);
    }
}
