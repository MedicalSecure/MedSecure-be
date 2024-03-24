
namespace Waste.API.Endpoints.Room;

//- Accepts a room ID as a parameter.
//- Constructs a DeleteRoomCommand with the room ID.
//- Sends the command for processing.
//- Returns a success or error response based on the outcome.

//public class DeleteRoom : ICarterModule
//{
//    public void AddRoutes(IEndpointRouteBuilder app)
//    {
//        app.MapDelete("/rooms/{roomId}", async (string roomId, ISender sender) =>
//        {
//            var result = await sender.Send(new DeleteRoomCommand(roomId));

//            if (result)
//            {
//                return Results.Ok("Room deleted successfully");
//            }
//            else
//            {
//                return Results.NotFound("Room not found");
//            }
//        })
//        .WithName("DeleteRoom")
//        .Produces(StatusCodes.Status200OK)
//        .Produces(StatusCodes.Status404NotFound)
//        .WithSummary("Delete Room")
//        .WithDescription("Delete Room by ID");
//    }
//}