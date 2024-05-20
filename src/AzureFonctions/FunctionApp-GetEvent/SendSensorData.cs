using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Azure.SignalR.Management;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

public static class SendSensorDataFunction
{
    private static readonly IServiceHubContext _hubContext;

    static SendSensorDataFunction()
    {
        var serviceManager = new ServiceManagerBuilder()
            .WithOptions(option =>
            {
                option.ConnectionString = Environment.GetEnvironmentVariable("AzureSignalRConnectionString");
            })
            .Build();
        _hubContext = serviceManager.CreateHubContextAsync("sensorHub").Result;
    }

    [Function("SendSensorData")]
    public static async Task Run(
        [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = null)] HttpRequestData req,
        FunctionContext executionContext)
    {
        var logger = executionContext.GetLogger("SendSensorDataFunction");
        logger.LogInformation("C# HTTP trigger function processed a request.");

        string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
        var data = JsonConvert.DeserializeObject<object>(requestBody);

        // Ensure data is not dynamic to avoid dynamic dispatch issues
        await _hubContext.Clients.All.SendAsync("ReceiveSensorData", data);

        var response = req.CreateResponse(System.Net.HttpStatusCode.OK);
        response.Headers.Add("Content-Type", "application/json");
        await response.WriteStringAsync(JsonConvert.SerializeObject(new { message = "Data sent to SignalR hub" }));

    }
}
