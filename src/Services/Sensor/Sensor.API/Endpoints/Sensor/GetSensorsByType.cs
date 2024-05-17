//namespace Sensor.API.Endpoints.Sensor;

//public record GetSensorByTypeResponse(IEnumerable<SensorDto> Sensors);
//public class GetSensorByType : ICarterModule
//{
//    public void AddRoutes(IEndpointRouteBuilder app)
//    {
//        app.MapGet("/v1/sensors/{sensortype}", async (SensorType sensortype, ISender sender) =>
//        {
//            var result = await sender.Send(new GetSensorsByTypeQuery(sensortype));

//            var response = result.Adapt<GetSensorByTypeResponse>();

//            return Results.Ok(response);
//        })
//        .WithName("GetSensorByType")
//        .Produces<GetSensorByTypeResponse>(StatusCodes.Status200OK)
//        .ProducesProblem(StatusCodes.Status400BadRequest)
//        .ProducesProblem(StatusCodes.Status404NotFound)
//        .WithSummary("Get Sensor ByType")
//        .WithDescription("Get Sensor By Type ");
//    }
//}
