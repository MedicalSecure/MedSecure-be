using System;
using System.Text;
using System.Threading.Tasks;
using Azure.Messaging.EventHubs;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Microsoft.Azure.SignalR.Management;
using Microsoft.AspNetCore.SignalR.Client;
using Microsoft.AspNetCore.SignalR;

namespace FunctionApp_GetEvent
{
    public class Function1
    {
        private readonly ILogger<Function1> _logger;
        private readonly IServiceProvider _serviceProvider;

        public Function1(ILogger<Function1> logger, IServiceProvider serviceProvider)
        {
            _logger = logger;
            _serviceProvider = serviceProvider;
        }





        [Function(nameof(Function1))]
        public async Task Run([EventHubTrigger("mediot-event", Connection = "EventHubConnection")] EventData[] events)
        {
            var connectionString = "Endpoint=https://medssecuresignalr.service.signalr.net;AccessKey=gPQBsWlNYqEld28/KlTgUjifIB91ciw2M+WFNz9qEFk=;Version=1.0;";
            var serviceManager = new ServiceManagerBuilder()
                .WithOptions(option =>
                {
                    option.ConnectionString = connectionString;
                })
                .Build();

            var hubContext = await serviceManager.CreateHubContextAsync("sensorHub");

            foreach (EventData eventData in events)
            {
                string messageBody = Encoding.UTF8.GetString(eventData.Body.ToArray());
                dynamic data = JsonConvert.DeserializeObject(messageBody);

                double temperature = data.temperature;
                double humidity = data.humidity;
                double electricity = data.electricity;
                double luminosity = data.luminosity;

                _logger.LogInformation($"Temperature: {temperature}, Humidity: {humidity}, Electricity: {electricity}, Luminosity: {luminosity}");

                // Envoyer les données au client Angular via SignalR
                await hubContext.Clients.All.SendAsync("UpdateData", new
                {
                    Temperature = temperature,
                    Humidity = humidity,
                    Electricity = electricity,
                    Luminosity = luminosity
                });

            }
        }
    }
}
