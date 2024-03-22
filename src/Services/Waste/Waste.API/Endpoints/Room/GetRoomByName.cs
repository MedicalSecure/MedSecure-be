
namespace Waste.API.Endpoints.Room
{
    //- Accepts a room name as a parameter.
    //- Constructs a GetRoomByNameQuery with the room name.
    //- Retrieves the data and returns it.

    public record GetRoomByNameRequest(string RoomName);
    public record GetRoomByNameResponse(RoomDto Room);

    public class GetRoomByName : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/rooms/{roomName}", async (string roomName, ISender sender) =>
            {
                var result = await sender.Send(new GetRoomByNameQuery(roomName));

                var response = result.Adapt<GetRoomByNameResponse>();

                if (response.Room != null)
                {
                    return Results.Ok(response);
                }
                else
                {
                    return Results.NotFound("Room not found");
                }
            })
            .WithName("GetRoomByName")
            .Produces<GetRoomByNameResponse>(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status404NotFound)
            .WithSummary("Get Room By Name")
            .WithDescription("Get Room By Name");
        }
    }
}
