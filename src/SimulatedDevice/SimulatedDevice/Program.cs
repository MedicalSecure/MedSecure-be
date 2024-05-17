using System;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using CommandLine;
using Microsoft.Azure.Devices.Client;

namespace SimulatedDevice
{
    internal class Program
    {
        private static TimeSpan s_telemetryInterval = TimeSpan.FromSeconds(10);

        private static async Task Main(string[] args)
        {
            Parameters parameters = null;
            ParserResult<Parameters> result = Parser.Default.ParseArguments<Parameters>(args)
                .WithParsed(parsedParams => parameters = parsedParams)
                .WithNotParsed(errors => Environment.Exit(1));

            Console.WriteLine("IoT Hub Quickstarts #1 - Simulated device.");

            using var deviceClient = DeviceClient.CreateFromConnectionString(parameters.DeviceConnectionString, parameters.TransportType);

            Console.WriteLine("Press control-C to exit.");
            using var cts = new CancellationTokenSource();
            Console.CancelKeyPress += (sender, eventArgs) =>
            {
                eventArgs.Cancel = true;
                cts.Cancel();
                Console.WriteLine("Exiting...");
            };

            await deviceClient.SetMethodDefaultHandlerAsync(DirectMethodCallback, null);

            await SendDeviceToCloudMessagesAsync(deviceClient, cts.Token);

            await deviceClient.CloseAsync();

            Console.WriteLine("Device simulator finished.");
        }

        private static Task<MethodResponse> DirectMethodCallback(MethodRequest methodRequest, object userContext)
        {
            Console.WriteLine($"Received direct method [{methodRequest.Name}] with payload [{methodRequest.DataAsJson}].");

            switch (methodRequest.Name)
            {
                case "SetTelemetryInterval":
                    try
                    {
                        int telemetryIntervalSeconds = JsonSerializer.Deserialize<int>(methodRequest.DataAsJson);
                        s_telemetryInterval = TimeSpan.FromSeconds(telemetryIntervalSeconds);
                        Console.WriteLine($"Setting the telemetry interval to {s_telemetryInterval}.");
                        return Task.FromResult(new MethodResponse(200));
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Failed to parse the payload for direct method {methodRequest.Name} due to {ex}");
                        break;
                    }
            }

            return Task.FromResult(new MethodResponse(400));
        }

        private static async Task SendDeviceToCloudMessagesAsync(DeviceClient deviceClient, CancellationToken ct)
        {
            double minTemperature = 20;
            double minHumidity = 60;
            double minElectricity = 100;
            double minLuminosity = 50;
            var rand = new Random();

            try
            {
                while (!ct.IsCancellationRequested)
                {
                    double currentTemperature = minTemperature + rand.NextDouble() * 15;
                    double currentHumidity = minHumidity + rand.NextDouble() * 20;
                    double currentElectricity = minElectricity + rand.NextDouble() * 200;
                    double currentLuminosity = minLuminosity + rand.NextDouble() * 100;

                    string messageBody = JsonSerializer.Serialize(
                        new
                        {
                            temperature = currentTemperature,
                            humidity = currentHumidity,
                            electricity = currentElectricity,
                            luminosity = currentLuminosity
                        });
                    using var message = new Message(Encoding.ASCII.GetBytes(messageBody))
                    {
                        ContentType = "application/json",
                        ContentEncoding = "utf-8",
                    };

                    // Add a custom application property to the message.
                    // An IoT hub can filter on these properties without access to the message body.
                    // message.Properties.Add("temperatureAlert", (currentTemperature > 30) ? "true" : "false");
                    // message.Properties.Add("level", "storage");

                    await deviceClient.SendEventAsync(message, ct);
                    Console.WriteLine($"{DateTime.Now} > Sending message: {messageBody}");

                    await Task.Delay(s_telemetryInterval, ct);
                }
            }
            catch (TaskCanceledException) { }
        }
    }
}
