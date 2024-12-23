using IoTSharedLibrary;
namespace IoTDataProcessor.Services
{
    public class AlertService
    {
        public Task SendAlertAsync(TelemetryData telemetry)
        {
            Console.WriteLine($"Alert! High temperature: {telemetry.Temperature} on Device: {telemetry.DeviceId}");
            return Task.CompletedTask;
        }
    }

}
