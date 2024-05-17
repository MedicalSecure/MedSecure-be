//using Sensor.Application.Dtos;

//namespace Sensor.API.Endpoints.Sensor;

//public record CreateSensorRequest(SensorDto Sensor);

//public record CreateSensorReponse(Guid Id);
//public class CreateSensor : ICarterModule
//{
//    public async void AddRoutes(IEndpointRouteBuilder app)
//    {
//        app.MapPost("/v1/sensor", async (CreateSensorRequest request, ISender sender) =>

//            {
//                var command = request.Adapt<CreateSensorCommand>();
//                var result = await sender.Send(command);
//                var response = result.Adapt<CreateSensorReponse>();
//                return Results.Created($"/Sensor/{response.Id}", response);

//            })
//         .WithName("CreateSensor")
//        .Produces<CreateSensorReponse>(StatusCodes.Status201Created)
//        .ProducesProblem(StatusCodes.Status400BadRequest)
//        .WithSummary("Create Sensor")
//        .WithDescription("Create sensor");

//    }
//}
