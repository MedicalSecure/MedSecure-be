
using Microsoft.Extensions.Configuration;
using Sensor.Domain.Models;
using System.Net.Http;

namespace Sensor.API.Endpoints.Sensor;

public record GetSensorsResponse(PaginatedResult<ThingspeakDto> thingspeakDto);

public class GetSensors : ICarterModule
{
    private readonly HttpClient httpClient;
    private readonly IConfiguration configuration;
    public GetSensors(HttpClient httpClient , IConfiguration configuration)
    {
        this.httpClient = httpClient;
        this.configuration=configuration;
    }
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/v1/sensors", async ([AsParameters] PaginationRequest request, ISender sender) =>
        {
            // call an extarnal api 
            var url = configuration.GetValue<string>("ExternalService:UrlThingSpeak");
            var responseAsync = await httpClient.GetAsync(url);
            responseAsync.EnsureSuccessStatusCode();
            var resultcall = await responseAsync.Content.ReadAsAsync<ThingSpeakDataResponse>();
            // var response = resultcall.Adapt<GetSensorsResponse>();
            return Results.Ok(resultcall);
        })
        .WithName("GetSensors")
        .Produces<GetSensorsResponse>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .ProducesProblem(StatusCodes.Status404NotFound)
        .WithSummary("Get all Sensor")
        .WithDescription("Get all Sensor");
    }
}