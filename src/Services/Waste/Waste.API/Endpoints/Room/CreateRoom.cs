
namespace Waste.API.Endpoints
{
    //- Accepts a CreateRoomRequest object.
    //- Maps the request to a CreateRoomCommand.
    //- Uses MediatR to send the command for processing.
    //- Returns a response with the created room's ID.

    public record CreateRoomRequest(RoomDto Room);
    public record CreateRoomResponse(string Id);

    public class CreateRoom : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPost("/rooms", async (CreateRoomRequest request, ISender sender) =>
            {
                var command = request.Adapt<CreateRoomCommand>();

                var result = await sender.Send(command);

                var response = result.Adapt<CreateRoomResponse>();

                return Results.Created($"/rooms/{response.Id}", response);
            })
            .WithName("CreateRoom")
            .Produces<CreateRoomResponse>(StatusCodes.Status201Created)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .WithSummary("Create Room")
            .WithDescription("Create Room");
        }
    }
}
