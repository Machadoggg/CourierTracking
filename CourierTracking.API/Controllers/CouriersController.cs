using CourierTracking.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CourierTracking.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CouriersController : ControllerBase
    {
        private readonly ICourierService _courierService;

        public CouriersController(ICourierService courierService)
        {
            _courierService = courierService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var couriers = await _courierService.GetAllCouriersAsync();
            return Ok(couriers);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var courier = await _courierService.GetCourierByIdAsync(id);
            return courier != null ? Ok(courier) : NotFound();
        }

        [HttpGet("{id}/locations")]
        public async Task<IActionResult> GetLocationHistory(int id)
        {
            var locations = await _courierService.GetCourierLocationHistoryAsync(id);
            return Ok(locations);
        }
    }
}
