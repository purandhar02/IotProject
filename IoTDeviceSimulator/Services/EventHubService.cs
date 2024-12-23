using IoTSharedLibrary;
using Azure.Messaging.EventHubs.Producer;
using System.Text.Json;

namespace IoTDeviceSimulator.Services
{
    public class EventHubService
    {
        private readonly EventHubProducerClient _producerClient;

        public EventHubService(string connectionString, string eventHubName)
        {
            _producerClient = new EventHubProducerClient(connectionString, eventHubName);
        }

        public async Task SendTelemetryAsync(TelemetryData data)
        {
            var eventData = new Azure.Messaging.EventHubs.EventData(JsonSerializer.Serialize(data));
            await _producerClient.SendAsync(new[] { eventData });
        }
    }
}
