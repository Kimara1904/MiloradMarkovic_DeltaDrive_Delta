using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MiloradMarkovic_DeltaDrive_Delta.DTOs;
using MiloradMarkovic_DeltaDrive_Delta.Services.Interfaces;

namespace MiloradMarkovic_DeltaDrive_Delta.Controllers
{
    [Route("api/passenger")]
    [ApiController]
    public class PassengersController : ControllerBase
    {
        private readonly IPassengerService _passengerService;

        public PassengersController(IPassengerService passengerService)
        {
            _passengerService = passengerService;
        }

        [Authorize]
        [HttpGet("history")]
        public async Task<ActionResult<List<HistoryPreviewDTO>>> GetHistory()
        {
            int passengerId = int.Parse(User.Claims.First(c => c.Type == "PassengerId").Value);

            return Ok(await _passengerService.GetHistoryPreview(passengerId));
        }
    }
}
