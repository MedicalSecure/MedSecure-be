
namespace Waste.API.Endpoints
{
    //- Accepts an UpdateRoomRequest.
    //- Maps the request to an UpdateRoomCommand.
    //- Sends the command for processing.
    //- Returns a success or error response based on the outcome.

    public record UpdateRoomRequest(RoomDto Room);
    public record UpdateRoomResponse(bool IsSuccess);

    public class UpdateRoom : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPut("/rooms", async (UpdateRoomRequest request, ISender sender) =>
            {
                var command = request.Adapt<UpdateRoomCommand>();

                var result = await sender.Send(command);

                var response = result.Adapt<UpdateRoomResponse>();

                return Results.Ok(response);
            })
            .WithName("UpdateRoom")
            .Produces<UpdateRoomResponse>(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .WithSummary("Update Room")
            .WithDescription("Update Room");
        }
    }
}