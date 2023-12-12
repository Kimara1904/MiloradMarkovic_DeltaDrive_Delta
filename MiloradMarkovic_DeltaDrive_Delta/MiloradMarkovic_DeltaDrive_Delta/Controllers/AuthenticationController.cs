using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MiloradMarkovic_DeltaDrive_Delta.DTOs;
using MiloradMarkovic_DeltaDrive_Delta.Services.Interfaces;

namespace MiloradMarkovic_DeltaDrive_Delta.Controllers
{
    [Route("api/authentication")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationService _authenticationService;

        public AuthenticationController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<ActionResult<TokenDTO>> Login(LoginDTO login)
        {
            string token = await _authenticationService.Login(login);
            return Ok(new TokenDTO { Token = token });
        }

        [HttpPost("register")]
        [AllowAnonymous]
        public async Task<ActionResult<string>> Register(RegisterDTO newPassenger)
        {
            await _authenticationService.Register(newPassenger);
            return Ok($"Successfully registered passenger with email: {newPassenger.Email}.");
        }
    }
}
