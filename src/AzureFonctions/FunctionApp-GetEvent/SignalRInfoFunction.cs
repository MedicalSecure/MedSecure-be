using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Azure.SignalR.Management;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

public static class SignalRInfoFunction
{
    private static readonly IServiceHubContext _hubContext;

    static SignalRInfoFunction()
    {
        var serviceManager = new ServiceManagerBuilder()
            .WithOptions(option =>
            {
                option.ConnectionString = Environment.GetEnvironmentVariable("AzureSignalRConnectionString");
            })
            .Build();
        _hubContext = serviceManager.CreateHubContextAsync("sensorHub").Result;
    }

    [Function("negotiate")]
    public static async Task<HttpResponseData> Negotiate([HttpTrigger(AuthorizationLevel.Anonymous, "post")] HttpRequestData req, FunctionContext executionContext)
    {
        var logger = executionContext.GetLogger("SignalRInfoFunction");

        logger.LogInformation("Negotiation endpoint called.");

        var negotiationResponse = new
        {
            accessToken = Guid.NewGuid().ToString()
        };

        var response = req.CreateResponse(System.Net.HttpStatusCode.OK);
        await response.WriteStringAsync(JsonConvert.SerializeObject(negotiationResponse));
        return response;
    }
}
