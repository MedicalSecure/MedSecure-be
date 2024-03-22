
namespace Waste.API.Endpoints
{
    //- Accepts pagination parameters.
    //- Constructs a GetRoomsQuery with these parameters.
    //- Retrieves the data and returns it in a paginated format.

    public record GetRoomsRequest(PaginationRequest PaginationRequest);
    public record GetRoomsResponse(PaginatedResult<RoomDto> Rooms);

    public class GetRooms : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/rooms", async ([AsParameters] PaginationRequest paginationRequest, ISender sender) =>
            {
                var result = await sender.Send(new GetRoomsQuery(paginationRequest));

                var response = result.Adapt<GetRoomsResponse>();

                return Results.Ok(response);
            })
            .WithName("GetRooms")
            .Produces<GetRoomsResponse>(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .ProducesProblem(StatusCodes.Status404NotFound)
            .WithSummary("Get Rooms")
            .WithDescription("Get Rooms");
        }
    }
}
