using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MiloradMarkovic_DeltaDrive_Delta.DTOs;
using MiloradMarkovic_DeltaDrive_Delta.Services.Interfaces;

namespace MiloradMarkovic_DeltaDrive_Delta.Controllers
{
    [Route("api/vehicle")]
    [ApiController]
    public class VehiclesController : ControllerBase
    {
        private readonly IVehicleService _vehicleService;

        public VehiclesController(IVehicleService vehicleService)
        {
            _vehicleService = vehicleService;
        }

        [Authorize]
        [HttpGet("available-vehicle")]
        public async Task<ActionResult<List<AvailableVehicleDTO>>> GetAvailableVehicles([FromQuery] AvailableVehicleLocationsDTO locations)
        {
            return Ok(await _vehicleService.GetAvailableVehicles(locations));
        }

        [Authorize]
        [HttpGet("rates")]
        public async Task<ActionResult<List<RatesPreviewDTO>>> GetRates(int id)
        {
            return Ok(await _vehicleService.GetRatesPreview(id));
        }

        [Authorize]
        [HttpGet("{id:int}")]
        public async Task<ActionResult<VehicleDetailDTO>> GetVehicleById(int id)
        {
            return Ok(await _vehicleService.GetVehicleById(id));
        }

        [Authorize]
        [HttpPut("book-vehicle")]
        public async Task<ActionResult<string>> BookVehicle(BookVehicleDTO bookVehicle)
        {
            int passengerId = int.Parse(User.Claims.First(c => c.Type == "PassengerId").Value);
            if (await _vehicleService.BookVehicle(passengerId, bookVehicle))
            {
                return Ok($"You successfully booked vehicle with id: {bookVehicle.Id}.");
            }
            return Ok("Driver deny your booking.");
        }

        [Authorize]
        [HttpPost("rate-vehicle")]
        public async Task<ActionResult<string>> RateVehicle(RateVehicleDTO rate)
        {
            int passengerId = int.Parse(User.Claims.First(c => c.Type == "PassengerId").Value);
            await _vehicleService.RateVehicle(passengerId, rate);

            return Ok($"You successfully rated vehicle with id: {rate.VehicleId}.");
        }
    }
}
