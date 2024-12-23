using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using System.Text;
using System.Text.Json;
using IoTDataProcessor.Services;
using IoTSharedLibrary;
using Microsoft.Azure.WebJobs;

namespace IoTDataProcessor.Functions
{
    public class ProcessTelemetryFunction
    {
        private readonly DatabaseService _databaseService;
        private readonly AlertService _alertService;
        private readonly DashboardService _dashboardService;

        public ProcessTelemetryFunction(DatabaseService databaseService, AlertService alertService, DashboardService dashboardService)
        {
            _databaseService = databaseService;
            _alertService = alertService;
            _dashboardService = dashboardService;
        }

        [FunctionName("ProcessTelemetry")]
        public async Task Run(
            [EventHubTrigger("myeventhub", Connection = "EventHubConnectionString")] Azure.Messaging.EventHubs.EventData[] events,
            ILogger log)
        {
            foreach (var eventData in events)
            {
                try
                {
                    var message = Encoding.UTF8.GetString(eventData.Body.ToArray());
                    var telemetry = JsonSerializer.Deserialize<TelemetryData>(message);

                    log.LogInformation($"Processing telemetry: {message}");

                    await _databaseService.SaveTelemetryAsync(telemetry);
                    if (telemetry.Temperature > 30)
                    {
                        await _alertService.SendAlertAsync(telemetry);
                    }
                    await _dashboardService.UpdateDashboardAsync(telemetry);
                }
                catch (Exception ex)
                {
                    log.LogError($"Error processing message: {ex.Message}");
                }
            }
        }
    }
}
