namespace Sensor.API.Endpoints.Sensor;

public record GetSensorByLocationResponse(IEnumerable<SensorDto> Sensors);
public class GetSensorByLocation : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/sensors/{location}", async (Location location, ISender sender) =>
        {
            var result = await sender.Send(new GetSensorsByLocationQuery(location));

            var response = result.Adapt<GetSensorByLocationResponse>();

            return Results.Ok(response);
        })
        .WithName("GetSensorByLocation")
        .Produces<GetSensorByLocationResponse>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .ProducesProblem(StatusCodes.Status404NotFound)
        .WithSummary("Get Sensor By Location")
        .WithDescription("Get Sensor By Location ");
    }
}
