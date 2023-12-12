using MiloradMarkovic_DeltaDrive_Delta.DTOs;

namespace MiloradMarkovic_DeltaDrive_Delta.Services.Interfaces
{
    public interface IAuthenticationService
    {
        Task<string> Login(string email, string password);
        Task Register(RegisterDTO newPassenger);
    }
}
