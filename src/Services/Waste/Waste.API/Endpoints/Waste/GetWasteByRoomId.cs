
namespace Waste.API.Endpoints.Waste;

//- Accepts a room ID as a parameter.
//- Constructs a GetWasteByRoomIdQuery with the room ID.
//- Retrieves the data and returns it.

public record GetWasteByRoomIdRequest(Guid RoomId);
public record GetWasteByRoomIdResponse(WasteDto Waste);

public class GetWasteByRoomId : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/wastes/room/{roomId}", async (Guid roomId, ISender sender) =>
        {
            var result = await sender.Send(new GetWasteByRoomIdQuery(roomId));

            var response = result.Adapt<GetWasteByRoomIdResponse>();

            if (response.Waste != null)
            {
                return Results.Ok(response);
            }
            else
            {
                return Results.NotFound("Waste not found for the given room ID");
            }
        })
        .WithName("GetWasteByRoomId")
        .Produces<GetWasteByRoomIdResponse>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status404NotFound)
        .WithSummary("Get Waste By Room ID")
        .WithDescription("Get Waste By Room ID");
    }
}