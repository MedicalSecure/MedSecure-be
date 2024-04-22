

namespace Sensor.API.Endpoints.Sensor;

public record GetSensorsResponse(PaginatedResult<SensorDto> Sensors);

public class GetSensors : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/v1/sensors", async ([AsParameters] PaginationRequest request, ISender sender) =>
        {
            var result = await sender.Send(new GetSensorsQuery(request));

            var response = result.Adapt<GetSensorsResponse>();

            return Results.Ok(response);
        })
        .WithName("GetSensors")
        .Produces<GetSensorsResponse>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .ProducesProblem(StatusCodes.Status404NotFound)
        .WithSummary("Get all Sensor")
        .WithDescription("Get all Sensor");
    }
}