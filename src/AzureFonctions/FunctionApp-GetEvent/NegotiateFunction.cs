using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.SignalR.Management;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace FunctionApp_GetEvent
{
    public class NegotiateFunction
    {
        private readonly ILogger<NegotiateFunction> _logger;

        public NegotiateFunction(ILogger<NegotiateFunction> logger)
        {
            _logger = logger;
        }

        [Function("NegotiateFunction")]
        public async Task<IActionResult> Run([HttpTrigger(AuthorizationLevel.Function, "post")] HttpRequest req)
        {
            var connectionString = "Endpoint=https://medssecuresignalr.service.signalr.net;AccessKey=gPQBsWlNYqEld28/KlTgUjifIB91ciw2M+WFNz9qEFk=;Version=1.0;";
            var serviceManager = new ServiceManagerBuilder()
                .WithOptions(option =>
                {
                    option.ConnectionString = connectionString;
                })
                .Build();

            var accessToken = serviceManager.GenerateClientAccessToken("sensorHub");
            var result = new { accessToken };

            return new OkObjectResult(result);
        }
    }
}
