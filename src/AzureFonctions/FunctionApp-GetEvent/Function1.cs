using System;
using System.Text;
using System.Threading.Tasks;
using Azure.Messaging.EventHubs;
using Microsoft.AspNetCore.Http.Connections;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.SignalR.Management;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace FunctionApp_GetEvent
{
    public class Function1
    {
        private readonly ILogger<Function1> _logger;
        private static readonly IServiceHubContext _hubContext;

        static Function1()
        {
            var serviceManager = new ServiceManagerBuilder()
                .WithOptions(option =>
                {
                    option.ConnectionString = Environment.GetEnvironmentVariable("AzureSignalRConnectionString");
                   
                })
                .Build();

            _hubContext = serviceManager.CreateHubContextAsync("sensorHub").Result;
        }

        public Function1(ILogger<Function1> logger)
        {
            _logger = logger;
        }

        public class SensorData
        {
            public double Temperature { get; set; }
            public double Humidity { get; set; }
            public double Electricity { get; set; }
            public double Luminosity { get; set; }
        }

        [Function(nameof(Function1))]
        public async Task Run([EventHubTrigger("mediot-event", Connection = "EventHubConnection")] EventData[] events)
        {
            foreach (EventData eventData in events)
            {
                string messageBody = Encoding.UTF8.GetString(eventData.Body.ToArray());
                var data = JsonConvert.DeserializeObject<SensorData>(messageBody);

                _logger.LogInformation($"Temperature: {data.Temperature}, Humidity: {data.Humidity}, Electricity: {data.Electricity}, Luminosity: {data.Luminosity}");

                await _hubContext.Clients.All.SendAsync("ReceiveSensorData", data);
            }
        }
    }
}
