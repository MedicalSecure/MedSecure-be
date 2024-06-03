using Prescription.Application.Features.UnitCare.Queries;
using Prescription.Domain.ValueObjects;

namespace Prescription.API.Endpoints.OccupiedRooms
{
    public record GetOccupiedRoomsResponse(PaginatedResult<EquipmentId> OccupiedRooms);

    public class GetOccupiedRooms : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/api/v1/UnitCare/OccupiedRooms", async ([AsParameters] PaginationRequest paginationRequest, ISender sender) =>
            {
                var result = await sender.Send(new GetOccupiedBedsQuery(paginationRequest));

                var response = result.Adapt<GetOccupiedRoomsResponse>();

                return Results.Ok(response);
            })
            .WithName($"Get {nameof(OccupiedRooms)}")
            .Produces<GetOccupiedRoomsResponse>(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .ProducesProblem(StatusCodes.Status404NotFound)
            .WithSummary($"Get {nameof(OccupiedRooms)}")
            .WithDescription($"Get {nameof(OccupiedRooms)}");
        }
    }
}