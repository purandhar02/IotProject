using IoTSharedLibrary;
namespace IoTDataProcessor.Services
{
    public class DatabaseService
    {
        public Task SaveTelemetryAsync(TelemetryData telemetry)
        {
            // Simulate saving to a database
            Console.WriteLine($"Saved telemetry: {telemetry.DeviceId}, {telemetry.Temperature}");
            return Task.CompletedTask;
        }
    }
}
