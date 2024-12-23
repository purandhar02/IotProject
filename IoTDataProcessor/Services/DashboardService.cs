using IoTSharedLibrary;
namespace IoTDataProcessor.Services
{
    public class DashboardService
    {
        public Task UpdateDashboardAsync(TelemetryData telemetry)
        {
            Console.WriteLine($"Dashboard updated for Device: {telemetry.DeviceId}");
            return Task.CompletedTask;
        }
    }

}
