using IoTSharedLibrary;
using IoTDeviceSimulator.Services;
using Microsoft.AspNetCore.Mvc;

namespace IoTDeviceSimulator.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TelemetryController : ControllerBase
    {
        private readonly EventHubService _eventHubService;

        public TelemetryController(EventHubService eventHubService)
        {
            _eventHubService = eventHubService;
        }

        [HttpPost]
        public async Task<IActionResult> SendTelemetry([FromBody] TelemetryData data)
        {
            await _eventHubService.SendTelemetryAsync(data);
            return Ok("Telemetry data sent to Event Hub.");
        }
    }
}
