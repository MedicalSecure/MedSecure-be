namespace UnitCare.API.Endpoints.Equipment;
public record GetEquipmentsResponse(PaginatedResult<EquipmentDto> Equipments);

public class GetEquipments : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/equipments", async ([AsParameters] PaginationRequest paginationRequest, ISender sender) =>
        {
            var result = await sender.Send(new Application.Equipments.Queries.GetEquipments.GetEquipmentsQuery(paginationRequest));

            var response = result.Adapt<GetEquipmentsResponse>();

            return Results.Ok(response);
        })
        .WithName("GetEquipments")
        .Produces<GetEquipmentsResponse>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .ProducesProblem(StatusCodes.Status404NotFound)
        .WithSummary("Get Equipments")
        .WithDescription("Get Equipments");
    }
}
